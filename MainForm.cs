using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Win32;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace AutoWALLPapper
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        private NotifyIcon trayIcon;
        private string htmlUrl = "https://valoemau1.blogspot.com/p/server.html"; // 🔧 URL chứa input có mảng JSON ảnh

        public MainForm()
        {
            InitializeComponent();
            InitTrayIcon();
            AddToStartup();
            this.Load += async (s, e) => await AutoRun();
        }

      

        private async Task AutoRun()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            List<string> imgUrls = await GetImageUrlsFromInput(htmlUrl);
            List<string> imgUrlsAvt = await GetImageUrlsFromInputAvatar(htmlUrl);

            if (imgUrls == null || imgUrls.Count == 0)
                return;

            using (HttpClient client = new HttpClient())
            {
                // 1. Avatar = ảnh đầu tiên
                string avatarUrl = imgUrlsAvt[0];
                string avatarPath = Path.Combine(Path.GetTempPath(), "user_avatar.jpg");
                var avatarBytes = await client.GetByteArrayAsync(avatarUrl);
                File.WriteAllBytes(avatarPath, avatarBytes);

                try
                {
                    string systemAvatarPath1 = @"C:\ProgramData\Microsoft\User Account Pictures\user.png";
                    File.Copy(avatarPath, systemAvatarPath1, true);

                    string systemAvatarPath2 = @"C:\ProgramData\Microsoft\User Account Pictures\user-32.png"; 
                    File.Copy(avatarPath, systemAvatarPath2, true);

                    string systemAvatarPath3 = @"C:\ProgramData\Microsoft\User Account Pictures\user-48.png";
                    File.Copy(avatarPath, systemAvatarPath3, true);

                    string systemAvatarPath4 = @"C:\ProgramData\Microsoft\User Account Pictures\user-64.png";
                    File.Copy(avatarPath, systemAvatarPath4, true);

                    string systemAvatarPath5 = @"C:\ProgramData\Microsoft\User Account Pictures\user-128.jpg";
                    File.Copy(avatarPath, systemAvatarPath5, true);

                    string systemAvatarPath6 = @"C:\ProgramData\Microsoft\User Account Pictures\user-192.png";
                    File.Copy(avatarPath, systemAvatarPath6, true);

                    string systemAvatarPath7 = @"C:\ProgramData\Microsoft\User Account Pictures\guest.png";
                    File.Copy(avatarPath, systemAvatarPath7, true);
                   
                    
                    
                    string systemAvatarPath8 = @"C:\ProgramData\Microsoft\User Account Pictures\guest.bmp";
                    File.Delete( systemAvatarPath8);

                    string systemAvatarPath9 = @"C:\ProgramData\Microsoft\User Account Pictures\user.bmp";
                    File.Delete(systemAvatarPath9);
                }
                catch { /* Bỏ qua nếu không đủ quyền */ }

                // 2. Wallpaper = ảnh thứ hai (nếu có) hoặc dùng lại
                string wallpaperUrl = imgUrls[0];
                string wallpaperPath = Path.Combine(Path.GetTempPath(), "wallpaper.png");
                var wallpaperBytes = await client.GetByteArrayAsync(wallpaperUrl);
                File.WriteAllBytes(wallpaperPath, wallpaperBytes);

                SetWallpaper(wallpaperPath);
            }

            Application.Exit();
        }

        private async Task<List<string>> GetImageUrlsFromInput(string htmlUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(htmlUrl);
                HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                var inputNode = doc.DocumentNode.SelectSingleNode("//input[@id='wallpapper']");
                if (inputNode == null) return new List<string>();

                string value = inputNode.GetAttributeValue("value", "[]");
                try
                {
                    return JsonSerializer.Deserialize<List<string>>(value);
                }
                catch
                {
                    return new List<string>();
                }
            }
        }
        private async Task<List<string>> GetImageUrlsFromInputAvatar(string htmlUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(htmlUrl);
                HtmlAgilityPack.HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                var inputNode = doc.DocumentNode.SelectSingleNode("//input[@id='avatar']");
                if (inputNode == null) return new List<string>();

                string value = inputNode.GetAttributeValue("value", "[]");
                try
                {
                    return JsonSerializer.Deserialize<List<string>>(value);
                }
                catch
                {
                    return new List<string>();
                }
            }
        }

        private void SetWallpaper(string path)
        {
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        private void AddToStartup()
        {
            try
            {
                string appName = "AgiliWallpaperAgent";
                string exePath = Application.ExecutablePath;
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                key.SetValue(appName, "\"" + exePath + "\"");
            }
            catch { }
        }

        private void InitTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Text = "AgiliWallpaperAgent";
            trayIcon.Icon = SystemIcons.Application;
            trayIcon.Visible = false;

            ContextMenuStrip trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Thoát", null, (s, e) => Application.Exit());
            trayIcon.ContextMenuStrip = trayMenu;
        }
    }
}
