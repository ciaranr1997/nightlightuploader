namespace DbdSSUploader
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
            this.isWatching = new System.Windows.Forms.CheckBox();
            this.currentSession = new System.Windows.Forms.ListBox();
            this.reuploadBtn = new System.Windows.Forms.Button();
            this.nlStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.nlStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // isWatching
            // 
            this.isWatching.Appearance = System.Windows.Forms.Appearance.Button;
            this.isWatching.AutoSize = true;
            this.isWatching.Location = new System.Drawing.Point(12, 12);
            this.isWatching.Name = "isWatching";
            this.isWatching.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.isWatching.Size = new System.Drawing.Size(86, 25);
            this.isWatching.TabIndex = 0;
            this.isWatching.Text = "Monitor Files";
            this.isWatching.UseVisualStyleBackColor = true;
            this.isWatching.CheckedChanged += new System.EventHandler(this.isWatching_CheckedChanged);
            // 
            // currentSession
            // 
            this.currentSession.FormattingEnabled = true;
            this.currentSession.ItemHeight = 15;
            this.currentSession.Location = new System.Drawing.Point(115, 12);
            this.currentSession.Name = "currentSession";
            this.currentSession.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.currentSession.Size = new System.Drawing.Size(246, 139);
            this.currentSession.TabIndex = 1;
            // 
            // reuploadBtn
            // 
            this.reuploadBtn.Location = new System.Drawing.Point(12, 128);
            this.reuploadBtn.Name = "reuploadBtn";
            this.reuploadBtn.Size = new System.Drawing.Size(86, 23);
            this.reuploadBtn.TabIndex = 2;
            this.reuploadBtn.Text = "Re-upload";
            this.reuploadBtn.UseVisualStyleBackColor = true;
            this.reuploadBtn.Click += new System.EventHandler(this.reuploadBtn_Click);
            // 
            // nlStatusStrip
            // 
            this.nlStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.nlStatusStrip.Location = new System.Drawing.Point(0, 159);
            this.nlStatusStrip.Name = "nlStatusStrip";
            this.nlStatusStrip.Size = new System.Drawing.Size(387, 22);
            this.nlStatusStrip.TabIndex = 3;
            this.nlStatusStrip.Text = "Waiting...";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 181);
            this.Controls.Add(this.nlStatusStrip);
            this.Controls.Add(this.reuploadBtn);
            this.Controls.Add(this.currentSession);
            this.Controls.Add(this.isWatching);
            this.Name = "MainForm";
            this.Text = "NightLight Autouploader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragLeave += new System.EventHandler(this.MainForm_DragLeave);
            this.nlStatusStrip.ResumeLayout(false);
            this.nlStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isWatching;
        private System.Windows.Forms.ListBox currentSession;
        private System.Windows.Forms.Button reuploadBtn;
        private System.Windows.Forms.StatusStrip nlStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}