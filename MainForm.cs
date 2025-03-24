using System.Diagnostics;

namespace RunMultiApps
{
    public partial class MainForm : Form
    {
        private int dragIndex;
        private object dragItem;
        private NotifyIcon trayIcon;
        private const string saveFilePath = "filelist.txt";
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = new Icon( new MemoryStream(Properties.Resources.iico));
            lstFiles.AllowDrop = true;
            lstFiles.DragEnter += LstFiles_DragEnter;
            lstFiles.DragDrop += LstFiles_DragDrop;
            lstFiles.MouseDown += LstFiles_MouseDown;
            lstFiles.DragOver += LstFiles_DragOver;

            // Thêm tray icon
            trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon(new MemoryStream(Properties.Resources.iico)); // Load icon từ source
            trayIcon.Text = "Multi File Runner";
            trayIcon.Visible = true;
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.ContextMenuStrip = CreateContextMenu();

            LoadFileList();

            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Mở", null, (s, e) => ShowForm());
            menu.Items.Add("Thu nhỏ", null, (s, e) => MinimizeToTray());
            menu.Items.Add("Thoát", null, (s, e) => Application.Exit());
            return menu;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void MinimizeToTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void LstFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void LstFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                lstFiles.Items.AddRange(files);
                SaveFileList();
            }
            else if (dragItem != null)
            {
                Point point = lstFiles.PointToClient(new Point(e.X, e.Y));
                int index = lstFiles.IndexFromPoint(point);
                if (index >= 0 && dragIndex != index)
                {
                    lstFiles.Items.RemoveAt(dragIndex);
                    lstFiles.Items.Insert(index, dragItem);
                }
            }
        }

        private void LstFiles_MouseDown(object sender, MouseEventArgs e)
        {
            dragIndex = lstFiles.IndexFromPoint(e.Location);
            if (dragIndex >= 0)
            {
                dragItem = lstFiles.Items[dragIndex];
                lstFiles.DoDragDrop(dragItem, DragDropEffects.Move);
            }
        }

        private void LstFiles_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "Executable & Batch Files|*.exe;*.bat|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lstFiles.Items.AddRange(openFileDialog.FileNames);
                SaveFileList();
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            foreach (var item in lstFiles.Items)
            {
                string filePath = item.ToString();
                if (File.Exists(filePath))
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo()
                        {
                            FileName = filePath,
                            UseShellExecute = true,
                            CreateNoWindow = false,
                            WorkingDirectory = Path.GetDirectoryName(filePath) // Chạy trong thư mục của chính nó
                        };
                        Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi chạy {filePath}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CloseRunningProcesses();
            lstFiles.Items.Clear();
            SaveFileList();
        }

        private void CloseRunningProcesses()
        {
            foreach (var item in lstFiles.Items)
            {
                string filePath = item.ToString();
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                var processes = Process.GetProcessesByName(fileName);
                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể đóng {fileName}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveFileList()
        {
            File.WriteAllLines(saveFilePath, lstFiles.Items.Cast<string>());
        }

        private void LoadFileList()
        {
            if (File.Exists(saveFilePath))
            {
                lstFiles.Items.AddRange(File.ReadAllLines(saveFilePath));
            }
        }
    
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }
    }
}
