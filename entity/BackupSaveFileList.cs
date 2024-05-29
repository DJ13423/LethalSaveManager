using LethalSaveManager.Properties;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSaveManager.entity
{
    public class BackupSaveFileList
    {
        Control parent; 
        int _selectedSaveFileIndex = 0;
        public int selectedSaveFileIndex
        {
            get { return _selectedSaveFileIndex; }
            set
            {
                _selectedSaveFileIndex = value;
                saveFileButtons.ForEach(saveFile =>
                {
                    saveFile.button.BackColor = Color.FromArgb(55, 1, 21);
                    saveFile.button.ForeColor = Color.FromArgb(211, 63, 35);
                    if (saveFile.creditsLabel != null)
                    {
                        saveFile.creditsLabel.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.quotaLabel.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.daysLabel.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.creditsText.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.quotaText.ForeColor = Color.FromArgb(150, 30, 20);
                        saveFile.daysText.ForeColor = Color.FromArgb(150, 30, 20);
                    }
                });
                if (value >= 0 && value < saveFileButtons.Count)
                {
                    saveFileButtons[value].button.BackColor = Color.FromArgb(198, 42, 12);
                    saveFileButtons[value].button.ForeColor = Color.Black;
                    if (saveFileButtons[value].creditsLabel != null)
                    {
                        saveFileButtons[value].creditsLabel.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].quotaLabel.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].daysLabel.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].creditsText.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].quotaText.ForeColor = Color.FromArgb(77, 0, 20);
                        saveFileButtons[value].daysText.ForeColor = Color.FromArgb(77, 0, 20);
                    }
                }
            }
        }
        public List<SaveFileButton> saveFileButtons = [];
        int lastButtonIndex = 0;
        Action refreshListCallback;
        int rightMargin;

        public BackupSaveFileList(Control parent, Action refreshListCallback, int rightMargin = 0)
        {
            this.parent = parent;
            this.refreshListCallback = refreshListCallback;
            this.rightMargin = rightMargin;
        }

        public void AddButton(string filePath, string name, string credits, string days, string quota)
        {
            int lastButtonIndexCopy = lastButtonIndex;

            Button saveFileButton = new Button();
            //saveFileButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            saveFileButton.BackColor = Color.FromArgb(55, 1, 21);
            saveFileButton.FlatAppearance.BorderColor = Color.Black;
            saveFileButton.FlatAppearance.BorderSize = 0;
            saveFileButton.FlatStyle = FlatStyle.Flat;
            saveFileButton.Font = new Font("Microsoft Sans Serif", 25 - Math.Min(name.Length * 0.5f, 10), FontStyle.Bold, GraphicsUnit.Point, 0);
            saveFileButton.ForeColor = Color.FromArgb(211, 63, 35);
            saveFileButton.ImageAlign = ContentAlignment.TopCenter;
            saveFileButton.Size = new Size(parent.Width - 100 - rightMargin, 90);
            saveFileButton.Location = new Point(25, 67 + (100 * lastButtonIndex));
            saveFileButton.Name = "saveFileButton";
            saveFileButton.TabIndex = 43;
            saveFileButton.Text = Uri.UnescapeDataString(name);
            saveFileButton.TextAlign = ContentAlignment.MiddleLeft;
            saveFileButton.UseVisualStyleBackColor = false;
            saveFileButton.Click += (sender, e) =>
            {
                selectedSaveFileIndex = lastButtonIndexCopy;
                LCSMUtility.RefreshActiveButton();
            };

            for (int i = 20; i < saveFileButton.Text.Length; i += 20)
            {
                if (saveFileButton.Text.Length > i)
                    saveFileButton.Text = saveFileButton.Text.Insert(i, Environment.NewLine);
            }

            Label saveCreditsLabel = null;
            Label saveQuotaLabel = null;
            Label saveDaysLabel = null;
            Label saveCreditsText = null;
            Label saveQuotaText = null;
            Label saveDaysText = null;
            Button deleteButton = null;

            if (credits != "" && days != "" && quota != "")
            {
                int labelsX = saveFileButton.Size.Width - 180;
                int valuesX = saveFileButton.Size.Width - 80;

                int creditsY = 0;
                int quotaY = 30;
                int daysY = 60;

                saveCreditsLabel = new Label();
                saveCreditsLabel.AutoSize = true;
                saveCreditsLabel.BackColor = Color.Transparent;
                saveCreditsLabel.Font = new Font("Segoe UI", 15F);
                saveCreditsLabel.ForeColor = Color.FromArgb(77, 0, 20);
                saveCreditsLabel.Location = new Point(labelsX, creditsY);
                saveCreditsLabel.Name = "saveCreditsText";
                saveCreditsLabel.Size = new Size(28, 28);
                saveCreditsLabel.TabIndex = 4;
                saveCreditsLabel.Text = "Credits:";
                saveCreditsLabel.TextAlign = ContentAlignment.MiddleCenter;

                saveQuotaLabel = new Label();
                saveQuotaLabel.AutoSize = true;
                saveQuotaLabel.BackColor = Color.Transparent;
                saveQuotaLabel.Font = new Font("Segoe UI", 15F);
                saveQuotaLabel.ForeColor = Color.FromArgb(77, 0, 20);
                saveQuotaLabel.Location = new Point(labelsX, quotaY);
                saveQuotaLabel.Name = "saveCreditsText";
                saveQuotaLabel.Size = new Size(28, 28);
                saveQuotaLabel.TabIndex = 4;
                saveQuotaLabel.Text = "Quota:";
                saveQuotaLabel.TextAlign = ContentAlignment.MiddleCenter;

                saveDaysLabel = new Label();
                saveDaysLabel.AutoSize = true;
                saveDaysLabel.BackColor = Color.Transparent;
                saveDaysLabel.Font = new Font("Segoe UI", 15F);
                saveDaysLabel.ForeColor = Color.FromArgb(77, 0, 20);
                saveDaysLabel.Location = new Point(labelsX, daysY);
                saveDaysLabel.Name = "saveCreditsText";
                saveDaysLabel.Size = new Size(28, 28);
                saveDaysLabel.TabIndex = 4;
                saveDaysLabel.Text = "Days:";
                saveDaysLabel.TextAlign = ContentAlignment.MiddleCenter;

                saveCreditsText = new Label();
                saveCreditsText.AutoSize = true;
                saveCreditsText.BackColor = Color.Transparent;
                saveCreditsText.Font = new Font("Segoe UI", 15F);
                saveCreditsText.ForeColor = Color.FromArgb(77, 0, 20);
                saveCreditsText.Location = new Point(valuesX, creditsY);
                saveCreditsText.Name = "saveCreditsText";
                saveCreditsText.Size = new Size(28, 28);
                saveCreditsText.TabIndex = 4;
                saveCreditsText.Text = credits;
                saveCreditsText.TextAlign = ContentAlignment.MiddleCenter;

                saveQuotaText = new Label();
                saveQuotaText.AutoSize = true;
                saveQuotaText.BackColor = Color.Transparent;
                saveQuotaText.Font = new Font("Segoe UI", 15F);
                saveQuotaText.ForeColor = Color.FromArgb(77, 0, 20);
                saveQuotaText.Location = new Point(valuesX, quotaY);
                saveQuotaText.Name = "saveQuotaText";
                saveQuotaText.Size = new Size(28, 28);
                saveQuotaText.TabIndex = 4;
                saveQuotaText.Text = quota;
                saveQuotaText.TextAlign = ContentAlignment.MiddleCenter;

                saveDaysText = new Label();
                saveDaysText.AutoSize = true;
                saveDaysText.BackColor = Color.Transparent;
                saveDaysText.Font = new Font("Segoe UI", 15F);
                saveDaysText.ForeColor = Color.FromArgb(77, 0, 20);
                saveDaysText.Location = new Point(valuesX, daysY);
                saveDaysText.Name = "saveDaysText";
                saveDaysText.Size = new Size(28, 28);
                saveDaysText.TabIndex = 4;
                saveDaysText.Text = days;
                saveDaysText.TextAlign = ContentAlignment.MiddleCenter;

                deleteButton = new Button();
                deleteButton.BackColor = Color.Transparent;
                deleteButton.FlatAppearance.BorderColor = Color.Black;
                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.FlatStyle = FlatStyle.Flat;
                deleteButton.Image = Resources.x_image;
                deleteButton.Size = new Size(50, 50);
                deleteButton.Location = saveFileButton.Location + new Size(saveFileButton.Size.Width + 10, (saveFileButton.Size.Height / 2) - (deleteButton.Height / 2));
                deleteButton.Name = "deleteButton";
                deleteButton.TabIndex = 48;
                deleteButton.UseVisualStyleBackColor = false;
                deleteButton.Click += (sender, e) =>
                {
                    if (File.Exists(filePath))
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to move this save file to the recycle bin?", "Delete Save File", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                    else
                    {
                        MessageBox.Show("File does not exist.");
                    }
                    refreshListCallback();
                };

                saveFileButton.Controls.Add(saveCreditsLabel);
                saveFileButton.Controls.Add(saveQuotaLabel);
                saveFileButton.Controls.Add(saveDaysLabel);
                saveFileButton.Controls.Add(saveCreditsText);
                saveFileButton.Controls.Add(saveQuotaText);
                saveFileButton.Controls.Add(saveDaysText);
                parent.Controls.Add(deleteButton);
            }
            parent.Controls.Add(saveFileButton);

            LCSMUtility.UseLethalCompanyFont(saveFileButton);

            saveFileButtons.Add(new SaveFileButton(filePath, saveFileButton, saveCreditsLabel, saveQuotaLabel, saveDaysLabel, saveCreditsText, saveDaysText, saveQuotaText, deleteButton));

            selectedSaveFileIndex = selectedSaveFileIndex;

            lastButtonIndex++;
        }

        public void Clear()
        {
            foreach (SaveFileButton saveFile in saveFileButtons)
            {
                saveFile.button.Dispose();
                saveFile.deleteButton?.Dispose();
            }
            saveFileButtons.Clear();
            lastButtonIndex = 0;
        }
    }
}
