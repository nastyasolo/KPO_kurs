namespace курсовая_кпо
{
    partial class MenuForm
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
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.SearchTaskTrainButton = new System.Windows.Forms.Button();
            this.AdminPanel = new System.Windows.Forms.Panel();
            this.UsersData = new System.Windows.Forms.Button();
            this.buttonLookData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuPanel.SuspendLayout();
            this.AdminPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(149)))), ((int)(((byte)(149)))));
            this.MenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuPanel.Controls.Add(this.SearchTaskTrainButton);
            this.MenuPanel.Controls.Add(this.AdminPanel);
            this.MenuPanel.Controls.Add(this.buttonLookData);
            this.MenuPanel.Controls.Add(this.panel2);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(451, 351);
            this.MenuPanel.TabIndex = 1;
            // 
            // SearchTaskTrainButton
            // 
            this.SearchTaskTrainButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.SearchTaskTrainButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchTaskTrainButton.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.SearchTaskTrainButton.FlatAppearance.BorderSize = 3;
            this.SearchTaskTrainButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SearchTaskTrainButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SearchTaskTrainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchTaskTrainButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTaskTrainButton.Location = new System.Drawing.Point(126, 160);
            this.SearchTaskTrainButton.Name = "SearchTaskTrainButton";
            this.SearchTaskTrainButton.Size = new System.Drawing.Size(184, 83);
            this.SearchTaskTrainButton.TabIndex = 24;
            this.SearchTaskTrainButton.Text = "Найти по времени";
            this.SearchTaskTrainButton.UseVisualStyleBackColor = false;
            this.SearchTaskTrainButton.Click += new System.EventHandler(this.SearchTaskTrainButton_Click);
            // 
            // AdminPanel
            // 
            this.AdminPanel.Controls.Add(this.UsersData);
            this.AdminPanel.Location = new System.Drawing.Point(27, 249);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(412, 135);
            this.AdminPanel.TabIndex = 23;
            // 
            // UsersData
            // 
            this.UsersData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.UsersData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsersData.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.UsersData.FlatAppearance.BorderSize = 3;
            this.UsersData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.UsersData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.UsersData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersData.Location = new System.Drawing.Point(99, 3);
            this.UsersData.Name = "UsersData";
            this.UsersData.Size = new System.Drawing.Size(184, 83);
            this.UsersData.TabIndex = 25;
            this.UsersData.Text = "Даннные пользователей";
            this.UsersData.UseVisualStyleBackColor = false;
            this.UsersData.Click += new System.EventHandler(this.UsersData_Click);
            // 
            // buttonLookData
            // 
            this.buttonLookData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonLookData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLookData.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.buttonLookData.FlatAppearance.BorderSize = 3;
            this.buttonLookData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonLookData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLookData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLookData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLookData.Location = new System.Drawing.Point(126, 71);
            this.buttonLookData.Name = "buttonLookData";
            this.buttonLookData.Size = new System.Drawing.Size(184, 83);
            this.buttonLookData.TabIndex = 15;
            this.buttonLookData.Text = "Просмотреть рейсы / купить билеты";
            this.buttonLookData.UseVisualStyleBackColor = false;
            this.buttonLookData.Click += new System.EventHandler(this.buttonLookData_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.panel2.Controls.Add(this.closeButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 65);
            this.panel2.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.SystemColors.InfoText;
            this.closeButton.Location = new System.Drawing.Point(424, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(24, 29);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "x";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "Меню ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 351);
            this.ControlBox = false;
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.MenuPanel.ResumeLayout(false);
            this.AdminPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLookData;
        private System.Windows.Forms.Panel AdminPanel;
        private System.Windows.Forms.Button SearchTaskTrainButton;
        private System.Windows.Forms.Button UsersData;
    }
}