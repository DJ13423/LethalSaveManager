namespace LethalSaveManager
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backupSaveButton = new Button();
            loadBackupButton = new Button();
            renameBackupButton = new Button();
            gameSaveFilesPanel = new Panel();
            gameSaveFileSelectionTitle = new Label();
            refreshSaveList = new Button();
            gameSaveFilesPanelBackPanel = new Panel();
            backupSaveFilesPanelBackPanel = new Panel();
            backupSavePaneRightMarginBar = new Panel();
            refreshBackupList = new Button();
            backupSaveFilesPanel = new Panel();
            backupSaveFileSectionTitle = new Label();
            noBackupsFoundLabel = new Label();
            openGameSaveDirectory = new Button();
            openBackupSaveDirectory = new Button();
            appVersionLabel = new Label();
            appTitle = new Label();
            gameSaveFilesPanel.SuspendLayout();
            gameSaveFilesPanelBackPanel.SuspendLayout();
            backupSaveFilesPanelBackPanel.SuspendLayout();
            backupSaveFilesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // backupSaveButton
            // 
            backupSaveButton.BackColor = Color.FromArgb(56, 0, 0);
            backupSaveButton.FlatAppearance.BorderSize = 0;
            backupSaveButton.FlatStyle = FlatStyle.Flat;
            backupSaveButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            backupSaveButton.ForeColor = Color.FromArgb(217, 247, 236);
            backupSaveButton.ImageAlign = ContentAlignment.TopCenter;
            backupSaveButton.Location = new Point(470, 110);
            backupSaveButton.Name = "backupSaveButton";
            backupSaveButton.Size = new Size(275, 75);
            backupSaveButton.TabIndex = 12;
            backupSaveButton.Text = "Backup Selected Game Save";
            backupSaveButton.UseVisualStyleBackColor = false;
            backupSaveButton.Click += BackupSelectedGameSaveButton_Click;
            // 
            // loadBackupButton
            // 
            loadBackupButton.BackColor = Color.FromArgb(56, 0, 0);
            loadBackupButton.FlatAppearance.BorderSize = 0;
            loadBackupButton.FlatStyle = FlatStyle.Flat;
            loadBackupButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            loadBackupButton.ForeColor = Color.FromArgb(217, 247, 236);
            loadBackupButton.ImageAlign = ContentAlignment.TopCenter;
            loadBackupButton.Location = new Point(470, 200);
            loadBackupButton.Name = "loadBackupButton";
            loadBackupButton.Size = new Size(275, 75);
            loadBackupButton.TabIndex = 11;
            loadBackupButton.Text = "Load Selected Backup into Selected Game Save File";
            loadBackupButton.UseVisualStyleBackColor = false;
            loadBackupButton.Click += LoadBackupButton_Click;
            // 
            // renameBackupButton
            // 
            renameBackupButton.BackColor = Color.FromArgb(56, 0, 0);
            renameBackupButton.FlatAppearance.BorderSize = 0;
            renameBackupButton.FlatStyle = FlatStyle.Flat;
            renameBackupButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            renameBackupButton.ForeColor = Color.FromArgb(217, 247, 236);
            renameBackupButton.ImageAlign = ContentAlignment.TopCenter;
            renameBackupButton.Location = new Point(470, 290);
            renameBackupButton.Name = "renameBackupButton";
            renameBackupButton.Size = new Size(275, 75);
            renameBackupButton.TabIndex = 21;
            renameBackupButton.Text = "Rename Selected Backup";
            renameBackupButton.UseVisualStyleBackColor = false;
            renameBackupButton.Click += RenameBackupButton_Click;
            // 
            // gameSaveFilesPanel
            // 
            gameSaveFilesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameSaveFilesPanel.BackColor = Color.FromArgb(48, 2, 21);
            gameSaveFilesPanel.Controls.Add(gameSaveFileSelectionTitle);
            gameSaveFilesPanel.Location = new Point(5, 5);
            gameSaveFilesPanel.Name = "gameSaveFilesPanel";
            gameSaveFilesPanel.Size = new Size(435, 400);
            gameSaveFilesPanel.TabIndex = 44;
            // 
            // gameSaveFileSelectionTitle
            // 
            gameSaveFileSelectionTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gameSaveFileSelectionTitle.AutoSize = true;
            gameSaveFileSelectionTitle.Font = new Font("Segoe UI", 22F);
            gameSaveFileSelectionTitle.ForeColor = Color.FromArgb(184, 25, 14);
            gameSaveFileSelectionTitle.Location = new Point(132, 5);
            gameSaveFileSelectionTitle.Name = "gameSaveFileSelectionTitle";
            gameSaveFileSelectionTitle.Size = new Size(132, 41);
            gameSaveFileSelectionTitle.TabIndex = 44;
            gameSaveFileSelectionTitle.Text = "Save File";
            gameSaveFileSelectionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // refreshSaveList
            // 
            refreshSaveList.FlatAppearance.BorderSize = 0;
            refreshSaveList.FlatStyle = FlatStyle.Flat;
            refreshSaveList.Image = Properties.Resources.refresh_icon;
            refreshSaveList.Location = new Point(385, 350);
            refreshSaveList.Name = "refreshSaveList";
            refreshSaveList.Size = new Size(50, 50);
            refreshSaveList.TabIndex = 3;
            refreshSaveList.UseVisualStyleBackColor = true;
            refreshSaveList.Click += refreshSaveList_Click;
            // 
            // gameSaveFilesPanelBackPanel
            // 
            gameSaveFilesPanelBackPanel.BackColor = Color.FromArgb(122, 0, 0);
            gameSaveFilesPanelBackPanel.Controls.Add(refreshSaveList);
            gameSaveFilesPanelBackPanel.Controls.Add(gameSaveFilesPanel);
            gameSaveFilesPanelBackPanel.Location = new Point(10, 10);
            gameSaveFilesPanelBackPanel.Name = "gameSaveFilesPanelBackPanel";
            gameSaveFilesPanelBackPanel.Size = new Size(445, 410);
            gameSaveFilesPanelBackPanel.TabIndex = 45;
            // 
            // backupSaveFilesPanelBackPanel
            // 
            backupSaveFilesPanelBackPanel.BackColor = Color.FromArgb(122, 0, 0);
            backupSaveFilesPanelBackPanel.Controls.Add(backupSavePaneRightMarginBar);
            backupSaveFilesPanelBackPanel.Controls.Add(refreshBackupList);
            backupSaveFilesPanelBackPanel.Controls.Add(backupSaveFilesPanel);
            backupSaveFilesPanelBackPanel.Location = new Point(760, 10);
            backupSaveFilesPanelBackPanel.Name = "backupSaveFilesPanelBackPanel";
            backupSaveFilesPanelBackPanel.Size = new Size(540, 410);
            backupSaveFilesPanelBackPanel.TabIndex = 46;
            // 
            // backupSavePaneRightMarginBar
            // 
            backupSavePaneRightMarginBar.BackColor = Color.FromArgb(122, 0, 0);
            backupSavePaneRightMarginBar.Location = new Point(535, 0);
            backupSavePaneRightMarginBar.Name = "backupSavePaneRightMarginBar";
            backupSavePaneRightMarginBar.Size = new Size(5, 410);
            backupSavePaneRightMarginBar.TabIndex = 47;
            // 
            // refreshBackupList
            // 
            refreshBackupList.FlatAppearance.BorderSize = 0;
            refreshBackupList.FlatStyle = FlatStyle.Flat;
            refreshBackupList.Image = Properties.Resources.refresh_icon;
            refreshBackupList.Location = new Point(480, 350);
            refreshBackupList.Name = "refreshBackupList";
            refreshBackupList.Size = new Size(50, 50);
            refreshBackupList.TabIndex = 45;
            refreshBackupList.UseVisualStyleBackColor = true;
            refreshBackupList.Click += refreshBackupList_Click;
            // 
            // backupSaveFilesPanel
            // 
            backupSaveFilesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            backupSaveFilesPanel.AutoScroll = true;
            backupSaveFilesPanel.AutoScrollMargin = new Size(0, 100);
            backupSaveFilesPanel.BackColor = Color.FromArgb(48, 2, 21);
            backupSaveFilesPanel.Controls.Add(backupSaveFileSectionTitle);
            backupSaveFilesPanel.Controls.Add(noBackupsFoundLabel);
            backupSaveFilesPanel.Location = new Point(5, 5);
            backupSaveFilesPanel.Name = "backupSaveFilesPanel";
            backupSaveFilesPanel.Size = new Size(548, 400);
            backupSaveFilesPanel.TabIndex = 44;
            backupSaveFilesPanel.Scroll += backupSaveFilesPanel_Scroll;
            // 
            // backupSaveFileSectionTitle
            // 
            backupSaveFileSectionTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            backupSaveFileSectionTitle.AutoSize = true;
            backupSaveFileSectionTitle.Font = new Font("Segoe UI", 22F);
            backupSaveFileSectionTitle.ForeColor = Color.FromArgb(184, 25, 14);
            backupSaveFileSectionTitle.Location = new Point(116, 5);
            backupSaveFileSectionTitle.Name = "backupSaveFileSectionTitle";
            backupSaveFileSectionTitle.Size = new Size(249, 41);
            backupSaveFileSectionTitle.TabIndex = 44;
            backupSaveFileSectionTitle.Text = "Backup Save Files";
            backupSaveFileSectionTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // noBackupsFoundLabel
            // 
            noBackupsFoundLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            noBackupsFoundLabel.AutoSize = true;
            noBackupsFoundLabel.Location = new Point(211, 200);
            noBackupsFoundLabel.Name = "noBackupsFoundLabel";
            noBackupsFoundLabel.Size = new Size(107, 15);
            noBackupsFoundLabel.TabIndex = 45;
            noBackupsFoundLabel.Text = "No Backups Found";
            noBackupsFoundLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // openGameSaveDirectory
            // 
            openGameSaveDirectory.BackColor = Color.FromArgb(56, 0, 0);
            openGameSaveDirectory.FlatAppearance.BorderSize = 0;
            openGameSaveDirectory.FlatStyle = FlatStyle.Flat;
            openGameSaveDirectory.Font = new Font("Segoe UI", 12F);
            openGameSaveDirectory.ForeColor = Color.FromArgb(254, 101, 22);
            openGameSaveDirectory.Location = new Point(64, 435);
            openGameSaveDirectory.Name = "openGameSaveDirectory";
            openGameSaveDirectory.Size = new Size(336, 30);
            openGameSaveDirectory.TabIndex = 49;
            openGameSaveDirectory.Text = "[ Open Game Save Directory ]";
            openGameSaveDirectory.UseVisualStyleBackColor = false;
            openGameSaveDirectory.Click += openGameSaveDirectory_Click;
            // 
            // openBackupSaveDirectory
            // 
            openBackupSaveDirectory.BackColor = Color.FromArgb(56, 0, 0);
            openBackupSaveDirectory.FlatAppearance.BorderSize = 0;
            openBackupSaveDirectory.FlatStyle = FlatStyle.Flat;
            openBackupSaveDirectory.Font = new Font("Segoe UI", 12F);
            openBackupSaveDirectory.ForeColor = Color.FromArgb(254, 101, 22);
            openBackupSaveDirectory.Location = new Point(862, 432);
            openBackupSaveDirectory.Name = "openBackupSaveDirectory";
            openBackupSaveDirectory.Size = new Size(336, 30);
            openBackupSaveDirectory.TabIndex = 50;
            openBackupSaveDirectory.Text = "[ Open Backup Save Directory ]";
            openBackupSaveDirectory.UseVisualStyleBackColor = false;
            openBackupSaveDirectory.Click += openBackupSaveDirectory_Click;
            // 
            // appVersionLabel
            // 
            appVersionLabel.AutoSize = true;
            appVersionLabel.Font = new Font("Segoe UI", 12F);
            appVersionLabel.Location = new Point(585, 55);
            appVersionLabel.Name = "appVersionLabel";
            appVersionLabel.Size = new Size(27, 21);
            appVersionLabel.TabIndex = 52;
            appVersionLabel.Text = "v1";
            // 
            // appTitle
            // 
            appTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            appTitle.AutoSize = true;
            appTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            appTitle.Location = new Point(460, 10);
            appTitle.MaximumSize = new Size(315, 0);
            appTitle.Name = "appTitle";
            appTitle.Size = new Size(250, 32);
            appTitle.TabIndex = 53;
            appTitle.Text = "Lethal Save Manager";
            appTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.FromArgb(29, 0, 0);
            ClientSize = new Size(1309, 481);
            Controls.Add(appTitle);
            Controls.Add(appVersionLabel);
            Controls.Add(openBackupSaveDirectory);
            Controls.Add(openGameSaveDirectory);
            Controls.Add(renameBackupButton);
            Controls.Add(backupSaveFilesPanelBackPanel);
            Controls.Add(gameSaveFilesPanelBackPanel);
            Controls.Add(backupSaveButton);
            Controls.Add(loadBackupButton);
            ForeColor = Color.FromArgb(147, 177, 166);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimumSize = new Size(700, 300);
            Name = "MainForm";
            Text = "Lethal Save Manager";
            Load += MainForm_Load;
            gameSaveFilesPanel.ResumeLayout(false);
            gameSaveFilesPanel.PerformLayout();
            gameSaveFilesPanelBackPanel.ResumeLayout(false);
            backupSaveFilesPanelBackPanel.ResumeLayout(false);
            backupSaveFilesPanel.ResumeLayout(false);
            backupSaveFilesPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button backupSaveButton;
        private Panel gameSaveFilesPanel;
        private Label gameSaveFileSelectionTitle;
        private Panel gameSaveFilesPanelBackPanel;
        private Panel backupSaveFilesPanelBackPanel;
        private Panel backupSaveFilesPanel;
        private Label backupSaveFileSectionTitle;
        private Button openGameSaveDirectory;
        private Button openBackupSaveDirectory;
        private Label noBackupsFoundLabel;
        internal Button loadBackupButton;
        internal Button renameBackupButton;
        private Label appVersionLabel;
        private Label appTitle;
        private Button refreshSaveList;
        private Button refreshBackupList;
        private Panel backupSavePaneRightMarginBar;
    }
}

