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
            this.UsersDataL = new System.Windows.Forms.Label();
            this.buttonDeleteData = new System.Windows.Forms.Button();
            this.buttonRedactData = new System.Windows.Forms.Button();
            this.buttonAddData = new System.Windows.Forms.Button();
            this.buttonSearchData = new System.Windows.Forms.Button();
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
            this.MenuPanel.Controls.Add(this.buttonSearchData);
            this.MenuPanel.Controls.Add(this.buttonLookData);
            this.MenuPanel.Controls.Add(this.panel2);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(451, 456);
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
            this.SearchTaskTrainButton.Location = new System.Drawing.Point(27, 193);
            this.SearchTaskTrainButton.Name = "SearchTaskTrainButton";
            this.SearchTaskTrainButton.Size = new System.Drawing.Size(184, 67);
            this.SearchTaskTrainButton.TabIndex = 24;
            this.SearchTaskTrainButton.Text = "Задание";
            this.SearchTaskTrainButton.UseVisualStyleBackColor = false;
            this.SearchTaskTrainButton.Click += new System.EventHandler(this.SearchTaskTrainButton_Click);
            // 
            // AdminPanel
            // 
            this.AdminPanel.Controls.Add(this.UsersDataL);
            this.AdminPanel.Controls.Add(this.buttonDeleteData);
            this.AdminPanel.Controls.Add(this.buttonRedactData);
            this.AdminPanel.Controls.Add(this.buttonAddData);
            this.AdminPanel.Location = new System.Drawing.Point(27, 266);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(412, 178);
            this.AdminPanel.TabIndex = 23;
            // 
            // UsersDataL
            // 
            this.UsersDataL.AutoSize = true;
            this.UsersDataL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersDataL.Location = new System.Drawing.Point(175, 146);
            this.UsersDataL.Name = "UsersDataL";
            this.UsersDataL.Size = new System.Drawing.Size(234, 24);
            this.UsersDataL.TabIndex = 22;
            this.UsersDataL.Text = "Даннные пользователей";
            this.UsersDataL.Click += new System.EventHandler(this.label4_Click);
            // 
            // buttonDeleteData
            // 
            this.buttonDeleteData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonDeleteData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteData.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.buttonDeleteData.FlatAppearance.BorderSize = 3;
            this.buttonDeleteData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonDeleteData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDeleteData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteData.Location = new System.Drawing.Point(0, 76);
            this.buttonDeleteData.Name = "buttonDeleteData";
            this.buttonDeleteData.Size = new System.Drawing.Size(184, 67);
            this.buttonDeleteData.TabIndex = 17;
            this.buttonDeleteData.Text = "Удалить рейс";
            this.buttonDeleteData.UseVisualStyleBackColor = false;
            this.buttonDeleteData.Click += new System.EventHandler(this.buttonDeleteData_Click);
            // 
            // buttonRedactData
            // 
            this.buttonRedactData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonRedactData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRedactData.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.buttonRedactData.FlatAppearance.BorderSize = 3;
            this.buttonRedactData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRedactData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRedactData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRedactData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRedactData.Location = new System.Drawing.Point(190, 3);
            this.buttonRedactData.Name = "buttonRedactData";
            this.buttonRedactData.Size = new System.Drawing.Size(184, 67);
            this.buttonRedactData.TabIndex = 18;
            this.buttonRedactData.Text = "Редактировать рейс";
            this.buttonRedactData.UseVisualStyleBackColor = false;
            this.buttonRedactData.Click += new System.EventHandler(this.buttonRedactData_Click);
            // 
            // buttonAddData
            // 
            this.buttonAddData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonAddData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddData.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.buttonAddData.FlatAppearance.BorderSize = 3;
            this.buttonAddData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonAddData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAddData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddData.Location = new System.Drawing.Point(0, 3);
            this.buttonAddData.Name = "buttonAddData";
            this.buttonAddData.Size = new System.Drawing.Size(184, 67);
            this.buttonAddData.TabIndex = 16;
            this.buttonAddData.Text = "Добавить рейс";
            this.buttonAddData.UseVisualStyleBackColor = false;
            this.buttonAddData.Click += new System.EventHandler(this.buttonAddData_Click);
            // 
            // buttonSearchData
            // 
            this.buttonSearchData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.buttonSearchData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchData.FlatAppearance.BorderColor = System.Drawing.Color.AntiqueWhite;
            this.buttonSearchData.FlatAppearance.BorderSize = 3;
            this.buttonSearchData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonSearchData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSearchData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchData.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearchData.Location = new System.Drawing.Point(217, 120);
            this.buttonSearchData.Name = "buttonSearchData";
            this.buttonSearchData.Size = new System.Drawing.Size(184, 67);
            this.buttonSearchData.TabIndex = 20;
            this.buttonSearchData.Text = "Найти";
            this.buttonSearchData.UseVisualStyleBackColor = false;
            this.buttonSearchData.Click += new System.EventHandler(this.buttonSearchData_Click);
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
            this.buttonLookData.Location = new System.Drawing.Point(27, 120);
            this.buttonLookData.Name = "buttonLookData";
            this.buttonLookData.Size = new System.Drawing.Size(184, 67);
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
            this.ClientSize = new System.Drawing.Size(451, 456);
            this.ControlBox = false;
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.MenuPanel.ResumeLayout(false);
            this.AdminPanel.ResumeLayout(false);
            this.AdminPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRedactData;
        private System.Windows.Forms.Button buttonDeleteData;
        private System.Windows.Forms.Button buttonAddData;
        private System.Windows.Forms.Button buttonLookData;
        private System.Windows.Forms.Button buttonSearchData;
        private System.Windows.Forms.Label UsersDataL;
        private System.Windows.Forms.Panel AdminPanel;
        private System.Windows.Forms.Button SearchTaskTrainButton;
    }
}