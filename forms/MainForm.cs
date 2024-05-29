using LethalSaveManager.forms;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using LethalSaveManager.entity;
using Microsoft.VisualBasic.FileIO;

namespace LethalSaveManager
{
    public partial class MainForm : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static MainForm instance;

        public static readonly string LocalLowPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\LocalLow\\";
        public static string GameSavePath = LocalLowPath + "ZeekerssRBLX\\Lethal Company\\";
        public static readonly string DefaultSaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LethalSaveManager\\GameSaveBackups\\";
        public static string CustomBackupDirectory = DefaultSaveDirectory;

        public static readonly string PlayerSave = "LCGeneralSaveData";

        public static LCPlayer PlayerInfo = new();
        public static LCSave saveInfo = new();
        public static LCSave BackupInfo = new();

        public static BackupSaveFileList backupSaveFileList;
        public static BackupSaveFileList gameSaveFileList;

        public MainForm()
        {
            if (instance == null)
                instance = this;
            else
                throw new Exception("Singleton instance MainForm already exists.");

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gameSaveFileList = new BackupSaveFileList(gameSaveFilesPanel, PopulateSaves);
            backupSaveFileList = new BackupSaveFileList(backupSaveFilesPanel, PopulateBackups, 10);

            //AllocConsole();

            LCSMUtility.UseLethalCompanyFont(this);

            Directory.CreateDirectory(DefaultSaveDirectory);

            PopulateSaves();

            gameSaveFileList.selectedSaveFileIndex = PlayerInfo.lastSelectedFile;

            PopulateBackups();

            LCSMUtility.RefreshActiveButton();

            Console.WriteLine("Lethal Company Save Manager started");
            backupSaveFilesPanel.VerticalScroll.Visible = false;
            /*string test = LCSecurity.Decrypt(File.ReadAllBytes(GameSavePath + PlayerSave));
			File.WriteAllText("corrupt.txt", test);*/
            /*string test = LCSecurity.Decrypt(File.ReadAllBytes(CustomBackupDirectory + "LCBackup2"));
			File.WriteAllText("backup.txt", test);*/
        }

        #region Loading and data
        private void PopulateSaves()
        {
            Console.WriteLine("Populating saves");
            gameSaveFileList.Clear();
            DirectoryInfo saveDir = new DirectoryInfo(GameSavePath);

            if (!saveDir.Exists)
            {
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile1", "File 1", "", "", "");
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile2", "File 2", "", "", "");
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile3", "File 3", "", "", "");
                return;
            }
            bool saveFile1Found = false;
            bool saveFile2Found = false;
            bool saveFile3Found = false;
            foreach (FileInfo item in saveDir.GetFiles())
            {
                if (item.Name == "LCSaveFile1")
                {
                    saveFile1Found = true;
                }
                else if (item.Name == "LCSaveFile2")
                {
                    saveFile2Found = true;
                }
                else if (item.Name == "LCSaveFile3")
                {
                    saveFile3Found = true;
                }
            }
            if (saveFile1Found)
            {
                LCSave save = new(GameSavePath + "LCSaveFile1");
                save.Load(GameSavePath + "LCSaveFile1");
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile1", "File 1", save.credits.ToString(), save.daySpent.ToString(), save.quota.ToString());
            }
            else
            {
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile1", "File 1", "", "", "");
            }
            if (saveFile2Found)
            {
                LCSave save = new(GameSavePath + "LCSaveFile2");
                save.Load(GameSavePath + "LCSaveFile2");
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile2", "File 2", save.credits.ToString(), save.daySpent.ToString(), save.quota.ToString());
            }
            else
            {
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile2", "File 2", "", "", "");
            }
            if (saveFile3Found)
            {
                LCSave save = new(GameSavePath + "LCSaveFile3");
                save.Load(GameSavePath + "LCSaveFile3");
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile3", "File 3", save.credits.ToString(), save.daySpent.ToString(), save.quota.ToString());
            }
            else
            {
                gameSaveFileList.AddButton(GameSavePath + "LCSaveFile3", "File 3", "", "", "");
            }
        }

        private void PopulateBackups()
        {
            backupSaveFilesPanel.VerticalScroll.Value = 0;
            Console.WriteLine("Populating backups");
            backupSaveFileList.Clear();

            if (!Directory.Exists(CustomBackupDirectory))
            {
                Directory.CreateDirectory(CustomBackupDirectory);
            }

            DirectoryInfo dir = new DirectoryInfo(CustomBackupDirectory);

            foreach (FileInfo item in dir.GetFiles())
            {
                LCSave save = new(item.FullName);
                save.Load(item.FullName);
                backupSaveFileList.AddButton(item.FullName, item.Name, save.credits.ToString(), save.daySpent.ToString(), save.quota.ToString());
            }

            if (backupSaveFileList.saveFileButtons.Count > 0)
                noBackupsFoundLabel.Visible = false;
            else
                noBackupsFoundLabel.Visible = true;

            LCSMUtility.RefreshActiveButton();
        }

        private void LoadPlayerData()
        {
            PlayerInfo.Load();
        }
        #endregion

        private void BackupSelectedGameSaveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Backup selected game save button clicked");
            string backupName = "";

            if (!Directory.Exists(CustomBackupDirectory))
            {
                Directory.CreateDirectory(CustomBackupDirectory);
            }

            DirectoryInfo backupDir = new DirectoryInfo(CustomBackupDirectory);

            FileInfo[] files = backupDir.GetFiles();

            backupName = "Backup " + (files.Count() + 1).ToString();

            // if file is already in the directory, increment the number untill the name is unique
            int i = 1;
            while (File.Exists(CustomBackupDirectory + backupName))
            {
                backupName = "Backup " + (files.Count() + i).ToString();
            }

            File.Copy(gameSaveFileList.saveFileButtons[gameSaveFileList.selectedSaveFileIndex].filePath, CustomBackupDirectory + backupName);

            PopulateBackups();

            backupSaveFileList.selectedSaveFileIndex = backupSaveFileList.saveFileButtons.FindIndex(x => x.filePath == CustomBackupDirectory + backupName);
        }

        private void LoadBackupButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load backup button clicked");
            string selectedBackup = backupSaveFileList.saveFileButtons[backupSaveFileList.selectedSaveFileIndex].filePath;
            string selectedSave = gameSaveFileList.saveFileButtons[gameSaveFileList.selectedSaveFileIndex].filePath;

            if (File.Exists(selectedBackup))
            {
                if (!Directory.Exists(GameSavePath))
                {
                    Directory.CreateDirectory(GameSavePath);
                }

                DialogResult confirmResult = DialogResult.None;
                if (File.Exists(selectedSave))
                {
                    confirmResult = MessageBox.Show("Are you sure to load this backup? This will overwrite the current selected save slot.", "Confirm Load Backup", MessageBoxButtons.YesNo);
                }

                // Delete the current save file if it exists and the user confirms
                if (File.Exists(selectedSave) && confirmResult == DialogResult.Yes)
                {
                    FileSystem.DeleteFile(selectedSave, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }

                // Copy the backup to the save slot
                if (!File.Exists(selectedSave) || confirmResult == DialogResult.Yes)
                {
                    File.Copy(selectedBackup, selectedSave);
                    PopulateSaves();
                }
            }
        }

        private void RenameBackupButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Rename backup button clicked");
            FileInfo backup = new FileInfo(backupSaveFileList.saveFileButtons[backupSaveFileList.selectedSaveFileIndex].filePath);
            if (backup.Exists)
            {
                RenameDialog renameDialog = new RenameDialog();
                renameDialog.fileNameTextBox.Text = Uri.UnescapeDataString(backup.Name);
                if (renameDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string litteral = Uri.EscapeDataString(renameDialog.fileNameTextBox.Text);
                    string newName = CustomBackupDirectory + litteral;
                    if (!File.Exists(newName))
                    {
                        File.Move(backup.FullName, newName);
                        PopulateBackups();
                    }
                }
            }
        }

        private void openGameSaveDirectory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening game save directory");
            Process.Start("explorer.exe", GameSavePath);
        }

        private void openBackupSaveDirectory_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Opening backup save directory");
            Process.Start("explorer.exe", CustomBackupDirectory);
        }

        private void refreshSaveList_Click(object sender, EventArgs e)
        {
            PopulateSaves();
        }

        private void refreshBackupList_Click(object sender, EventArgs e)
        {
            PopulateBackups();
        }
    }
}
