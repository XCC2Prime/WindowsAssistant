namespace Windows_Assistant
{
    partial class WindowsAssistant
    {
        private System.ComponentModel.IContainer Components = null;

        protected override void Dispose(bool Disposing)
        {
            if (Disposing && (Components != null)) { Components.Dispose(); }
            base.Dispose(Disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsAssistant));
            this.BoxReg = new System.Windows.Forms.TextBox();
            this.BtnRegAdd = new System.Windows.Forms.Button();
            this.BtnRegDelete = new System.Windows.Forms.Button();
            this.LabelProcess = new System.Windows.Forms.Label();
            this.CheckUpdates = new System.Windows.Forms.CheckBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnUpdates = new System.Windows.Forms.Button();
            this.CheckControlPanel = new System.Windows.Forms.CheckBox();
            this.CheckRegedit = new System.Windows.Forms.CheckBox();
            this.BtnRegedit = new System.Windows.Forms.Button();
            this.BtnControlPanel = new System.Windows.Forms.Button();
            this.BtnSeconds = new System.Windows.Forms.Button();
            this.CheckSeconds = new System.Windows.Forms.CheckBox();
            this.CheckNet = new System.Windows.Forms.CheckBox();
            this.BtnNet = new System.Windows.Forms.Button();
            this.BtnEnglish = new System.Windows.Forms.Button();
            this.BtnRussian = new System.Windows.Forms.Button();
            this.LinkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.LabelUpdate = new System.Windows.Forms.Label();
            this.BtnScheme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            this.BoxReg.Location = new System.Drawing.Point(12, 61);
            this.BoxReg.Name = "BoxReg";
            this.BoxReg.Size = new System.Drawing.Size(560, 20);
            this.BoxReg.TabIndex = 0;
            this.BoxReg.Text = "Введите расширение файла без точки";
            this.BoxReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            
            this.BtnRegAdd.Location = new System.Drawing.Point(12, 87);
            this.BtnRegAdd.Name = "BtnRegAdd";
            this.BtnRegAdd.Size = new System.Drawing.Size(275, 25);
            this.BtnRegAdd.TabIndex = 1;
            this.BtnRegAdd.Text = "Добавить";
            this.BtnRegAdd.UseVisualStyleBackColor = true;
            this.BtnRegAdd.Click += new System.EventHandler(this.BtnRegAdd_Click);
            
            this.BtnRegDelete.Location = new System.Drawing.Point(297, 87);
            this.BtnRegDelete.Name = "BtnRegDelete";
            this.BtnRegDelete.Size = new System.Drawing.Size(275, 25);
            this.BtnRegDelete.TabIndex = 2;
            this.BtnRegDelete.Text = "Удалить";
            this.BtnRegDelete.UseVisualStyleBackColor = true;
            this.BtnRegDelete.Click += new System.EventHandler(this.BtnRegDelete_Click);
            
            this.LabelProcess.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LabelProcess.Location = new System.Drawing.Point(12, 9);
            this.LabelProcess.Name = "LabelProcess";
            this.LabelProcess.Size = new System.Drawing.Size(560, 50);
            this.LabelProcess.TabIndex = 6;
            this.LabelProcess.Text = "Здесь будет появляться информация о действиях Windows Assistant";
            this.LabelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            this.CheckUpdates.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckUpdates.Location = new System.Drawing.Point(118, 118);
            this.CheckUpdates.Name = "CheckUpdates";
            this.CheckUpdates.Size = new System.Drawing.Size(454, 25);
            this.CheckUpdates.TabIndex = 8;
            this.CheckUpdates.Text = "[1] - Отключить обновления Windows";
            this.CheckUpdates.UseVisualStyleBackColor = true;
            
            this.BtnApply.Location = new System.Drawing.Point(12, 303);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(560, 25);
            this.BtnApply.TabIndex = 9;
            this.BtnApply.Text = "Применить";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            
            this.BtnUpdates.Location = new System.Drawing.Point(12, 118);
            this.BtnUpdates.Name = "BtnUpdates";
            this.BtnUpdates.Size = new System.Drawing.Size(100, 25);
            this.BtnUpdates.TabIndex = 10;
            this.BtnUpdates.Text = "Востановить";
            this.BtnUpdates.UseVisualStyleBackColor = true;
            this.BtnUpdates.Click += new System.EventHandler(this.BtnUpdates_Click);
             
            this.CheckControlPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckControlPanel.Location = new System.Drawing.Point(118, 149);
            this.CheckControlPanel.Name = "CheckControlPanel";
            this.CheckControlPanel.Size = new System.Drawing.Size(454, 25);
            this.CheckControlPanel.TabIndex = 11;
            this.CheckControlPanel.Text = "[2] - Добавить в контекстное меню рабочего стола пункт \"Панель управления\"";
            this.CheckControlPanel.UseVisualStyleBackColor = true;
             
            this.CheckRegedit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckRegedit.Location = new System.Drawing.Point(118, 180);
            this.CheckRegedit.Name = "CheckRegedit";
            this.CheckRegedit.Size = new System.Drawing.Size(454, 25);
            this.CheckRegedit.TabIndex = 13;
            this.CheckRegedit.Text = "[3] - Добавить в контекстное меню рабочего стола пункт \"Редактор реестра\"";
            this.CheckRegedit.UseVisualStyleBackColor = true;
            
            this.BtnRegedit.Location = new System.Drawing.Point(12, 180);
            this.BtnRegedit.Name = "BtnRegedit";
            this.BtnRegedit.Size = new System.Drawing.Size(100, 25);
            this.BtnRegedit.TabIndex = 16;
            this.BtnRegedit.Text = "Востановить";
            this.BtnRegedit.UseVisualStyleBackColor = true;
            this.BtnRegedit.Click += new System.EventHandler(this.BtnRegedit_Click);
            
            this.BtnControlPanel.Location = new System.Drawing.Point(12, 149);
            this.BtnControlPanel.Name = "BtnControlPanel";
            this.BtnControlPanel.Size = new System.Drawing.Size(100, 25);
            this.BtnControlPanel.TabIndex = 15;
            this.BtnControlPanel.Text = "Востановить";
            this.BtnControlPanel.UseVisualStyleBackColor = true;
            this.BtnControlPanel.Click += new System.EventHandler(this.BtnControlPanel_Click);
            
            this.BtnSeconds.Location = new System.Drawing.Point(12, 211);
            this.BtnSeconds.Name = "BtnSeconds";
            this.BtnSeconds.Size = new System.Drawing.Size(100, 25);
            this.BtnSeconds.TabIndex = 18;
            this.BtnSeconds.Text = "Востановить";
            this.BtnSeconds.UseVisualStyleBackColor = true;
            this.BtnSeconds.Click += new System.EventHandler(this.BtnSeconds_Click);
             
            this.CheckSeconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckSeconds.Location = new System.Drawing.Point(118, 211);
            this.CheckSeconds.Name = "CheckSeconds";
            this.CheckSeconds.Size = new System.Drawing.Size(454, 25);
            this.CheckSeconds.TabIndex = 17;
            this.CheckSeconds.Text = "[4] - Добавить отображение секунд в часах панели задач";
            this.CheckSeconds.UseVisualStyleBackColor = true;
            
            this.CheckNet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckNet.Location = new System.Drawing.Point(118, 242);
            this.CheckNet.Name = "CheckNet";
            this.CheckNet.Size = new System.Drawing.Size(454, 25);
            this.CheckNet.TabIndex = 19;
            this.CheckNet.Text = "[5] - Убрать отображение пункта \"Сеть\" в проводнике";
            this.CheckNet.UseVisualStyleBackColor = true;
             
            this.BtnNet.Location = new System.Drawing.Point(12, 241);
            this.BtnNet.Name = "BtnNet";
            this.BtnNet.Size = new System.Drawing.Size(100, 25);
            this.BtnNet.TabIndex = 20;
            this.BtnNet.Text = "Востановить";
            this.BtnNet.UseVisualStyleBackColor = true;
            this.BtnNet.Click += new System.EventHandler(this.BtnNet_Click);
            
            this.BtnEnglish.Location = new System.Drawing.Point(12, 334);
            this.BtnEnglish.Name = "BtnEnglish";
            this.BtnEnglish.Size = new System.Drawing.Size(100, 25);
            this.BtnEnglish.TabIndex = 21;
            this.BtnEnglish.Text = "English";
            this.BtnEnglish.UseVisualStyleBackColor = true;
            this.BtnEnglish.Click += new System.EventHandler(this.BtnEnglish_Click);
            
            this.BtnRussian.Location = new System.Drawing.Point(118, 334);
            this.BtnRussian.Name = "BtnRussian";
            this.BtnRussian.Size = new System.Drawing.Size(100, 25);
            this.BtnRussian.TabIndex = 22;
            this.BtnRussian.Text = "Русский";
            this.BtnRussian.UseVisualStyleBackColor = true;
            this.BtnRussian.Click += new System.EventHandler(this.BtnRussian_Click);
            
            this.LinkLabelGitHub.AutoSize = true;
            this.LinkLabelGitHub.Location = new System.Drawing.Point(532, 340);
            this.LinkLabelGitHub.Name = "LinkLabelGitHub";
            this.LinkLabelGitHub.Size = new System.Drawing.Size(40, 13);
            this.LinkLabelGitHub.TabIndex = 23;
            this.LinkLabelGitHub.TabStop = true;
            this.LinkLabelGitHub.Text = "GitHub";
            this.LinkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelGitHub_Click);
            
            this.LabelUpdate.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LabelUpdate.Location = new System.Drawing.Point(224, 337);
            this.LabelUpdate.Name = "LabelUpdate";
            this.LabelUpdate.Size = new System.Drawing.Size(311, 19);
            this.LabelUpdate.TabIndex = 24;
            this.LabelUpdate.Text = "Вы используете последнию версию Windows Assistant -";
            this.LabelUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
             
            this.BtnScheme.Location = new System.Drawing.Point(12, 272);
            this.BtnScheme.Name = "BtnScheme";
            this.BtnScheme.Size = new System.Drawing.Size(560, 25);
            this.BtnScheme.TabIndex = 25;
            this.BtnScheme.Text = "Разблокировать и активировать схему электропитания \"Максимальная производительность\"";
            this.BtnScheme.UseVisualStyleBackColor = true;
            this.BtnScheme.Click += new System.EventHandler(this.BtnScheme_Click);
             
            this.AcceptButton = this.BtnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 365);
            this.Controls.Add(this.BtnScheme);
            this.Controls.Add(this.LabelUpdate);
            this.Controls.Add(this.LinkLabelGitHub);
            this.Controls.Add(this.BtnRussian);
            this.Controls.Add(this.BtnEnglish);
            this.Controls.Add(this.BtnNet);
            this.Controls.Add(this.CheckNet);
            this.Controls.Add(this.BtnSeconds);
            this.Controls.Add(this.CheckSeconds);
            this.Controls.Add(this.BtnRegedit);
            this.Controls.Add(this.BtnControlPanel);
            this.Controls.Add(this.CheckRegedit);
            this.Controls.Add(this.CheckControlPanel);
            this.Controls.Add(this.BtnUpdates);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.CheckUpdates);
            this.Controls.Add(this.LabelProcess);
            this.Controls.Add(this.BtnRegDelete);
            this.Controls.Add(this.BtnRegAdd);
            this.Controls.Add(this.BoxReg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WindowsAssistant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Assistant - Version 1.0.0.0";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox BoxReg;
        private System.Windows.Forms.Button BtnRegAdd;
        private System.Windows.Forms.Button BtnRegDelete;
        private System.Windows.Forms.Label LabelProcess;
        private System.Windows.Forms.CheckBox CheckUpdates;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnUpdates;
        private System.Windows.Forms.CheckBox CheckControlPanel;
        private System.Windows.Forms.CheckBox CheckRegedit;
        private System.Windows.Forms.Button BtnRegedit;
        private System.Windows.Forms.Button BtnControlPanel;
        private System.Windows.Forms.Button BtnSeconds;
        private System.Windows.Forms.CheckBox CheckSeconds;
        private System.Windows.Forms.CheckBox CheckNet;
        private System.Windows.Forms.Button BtnNet;
        private System.Windows.Forms.Button BtnEnglish;
        private System.Windows.Forms.Button BtnRussian;
        private System.Windows.Forms.LinkLabel LinkLabelGitHub;
        private System.Windows.Forms.Label LabelUpdate;
        private System.Windows.Forms.Button BtnScheme;
    }
}