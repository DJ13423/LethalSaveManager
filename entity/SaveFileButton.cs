using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalSaveManager.entity
{
    public class SaveFileButton
    {
        public string filePath;
        public Button button;
        public string name;
        public Label creditsLabel;
        public Label quotaLabel;
        public Label daysLabel;
        public Label creditsText;
        public Label quotaText;
        public Label daysText;
        public Button deleteButton;

        public SaveFileButton(string filePath, Button button, Label creditsLabel, Label quotaLabel, Label daysLabel, Label creditsText, Label quotaText, Label daysText, Button deleteButton)
        {
            this.filePath = filePath;
            this.button = button;
            this.creditsLabel = creditsLabel;
            this.quotaLabel = quotaLabel;
            this.daysLabel = daysLabel;
            this.creditsText = creditsText;
            this.quotaText = quotaText;
            this.daysText = daysText;
            this.deleteButton = deleteButton;
        }

        public void SetFilePath(string filePath)
        {
            this.filePath = filePath;
        }

        public void SetFileName(string name)
        {
            button.Text = name;
            this.name = name;
        }

        public void SetCredits(int credits)
        {
            creditsText.Text = credits.ToString();
        }

        public void SetDays(int days)
        {
            daysText.Text = days.ToString();
        }

        public void SetQuota(int quota)
        {
            quotaText.Text = quota.ToString();
        }
    }
}
