namespace LethalSaveManager.forms
{
	partial class RenameDialog
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
            label2 = new Label();
            confirmButton = new Button();
            cancelButton = new Button();
            fileNameTextBox = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(252, 25, 0);
            label2.Location = new Point(18, 20);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(234, 28);
            label2.TabIndex = 1;
            label2.Text = "Rename Save";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // confirmButton
            // 
            confirmButton.BackColor = Color.FromArgb(24, 91, 61);
            confirmButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirmButton.ForeColor = Color.FromArgb(217, 247, 236);
            confirmButton.ImageAlign = ContentAlignment.TopCenter;
            confirmButton.Location = new Point(149, 100);
            confirmButton.Margin = new Padding(4, 3, 4, 3);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(103, 27);
            confirmButton.TabIndex = 2;
            confirmButton.Text = "Rename";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += SaveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(124, 61, 61);
            cancelButton.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = Color.FromArgb(217, 247, 236);
            cancelButton.ImageAlign = ContentAlignment.TopCenter;
            cancelButton.Location = new Point(18, 100);
            cancelButton.Margin = new Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(103, 27);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Back";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // fileNameTextBox
            // 
            fileNameTextBox.BackColor = Color.FromArgb(24, 61, 61);
            fileNameTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileNameTextBox.ForeColor = Color.FromArgb(247, 247, 247);
            fileNameTextBox.Location = new Point(18, 65);
            fileNameTextBox.Margin = new Padding(4, 3, 4, 3);
            fileNameTextBox.Name = "fileNameTextBox";
            fileNameTextBox.Size = new Size(234, 26);
            fileNameTextBox.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(56, 0, 0);
            panel1.Controls.Add(confirmButton);
            panel1.Controls.Add(cancelButton);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(fileNameTextBox);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 160);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(56, 0, 0);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(288, 179);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(154, 0, 0);
            panel3.Controls.Add(panel1);
            panel3.Location = new Point(6, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(276, 167);
            panel3.TabIndex = 5;
            // 
            // RenameDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(154, 0, 0);
            ClientSize = new Size(294, 185);
            Controls.Add(panel2);
            ForeColor = Color.FromArgb(147, 177, 166);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "RenameDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rename Save File";
            Load += RenameDialog_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Button confirmButton;
        private Button cancelButton;
        internal TextBox fileNameTextBox;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
    }
}