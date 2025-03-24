using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RunMultiApps
{
    public class FontManager : Form
    {
        private static PrivateFontCollection fonts = new PrivateFontCollection();

        public static Font LoadFont(float size, FontStyle style = FontStyle.Regular)
        {
            if (fonts.Families.Length == 0)
            {
                string resourceName = "RunMultiApps.Resources.fa-solid-900.ttf"; // Đổi tên namespace
                using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (fontStream != null)
                    {
                        byte[] fontData = new byte[fontStream.Length];
                        fontStream.Read(fontData, 0, (int)fontStream.Length);
                        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                        fonts.AddMemoryFont(fontPtr, fontData.Length);
                        Marshal.FreeCoTaskMem(fontPtr);
                    }
                }
            }
            return new Font(fonts.Families[0], size, style);
        }
    }

}
