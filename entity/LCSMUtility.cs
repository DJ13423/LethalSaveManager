using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LethalSaveManager.entity
{
    static class LCSMUtility
    {
        [DllImport("Gdi32.dll", SetLastError = true)]
        public static extern IntPtr AddFontMemResourceEx(IntPtr pFileView, int cjSize, IntPtr pvResrved, out int pNumFonts);

        static void ChangeFontRecursively(Control control, PrivateFontCollection pfc)
        {
            control.Font = new Font(pfc.Families[0], control.Font.Size + 1, control.Font.Style);
            foreach (Control c in control.Controls)
            {
                ChangeFontRecursively(c, pfc);
            }
        }

        static byte[] fontData = Properties.Resources._3270_regular_font;
        static IntPtr fontDataPointer = Marshal.AllocCoTaskMem(fontData.Length);
        static PrivateFontCollection pfc = new PrivateFontCollection();
        static bool fontLoaded = false;

        public static void UseLethalCompanyFont(Control control)
        {
            if (!fontLoaded)
            {
                Marshal.Copy(fontData, 0, fontDataPointer, fontData.Length);
                int nNumFonts;
                AddFontMemResourceEx(fontDataPointer, fontData.Length, IntPtr.Zero, out nNumFonts);
                pfc.AddMemoryFont(fontDataPointer, fontData.Length);
                fontLoaded = true;
            }
            ChangeFontRecursively(control, pfc);
        }

        public static void RefreshActiveButton()
        {
            if (MainForm.backupSaveFileList.selectedSaveFileIndex >= MainForm.backupSaveFileList.saveFileButtons.Count)
            {
                MainForm.instance.loadBackupButton.Enabled = false;
                MainForm.instance.renameBackupButton.Enabled = false;
            }
            else
            {
                MainForm.instance.loadBackupButton.Enabled = true;
                MainForm.instance.renameBackupButton.Enabled = true;
            }
        }
    }
}
