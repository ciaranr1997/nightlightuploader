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
            this.currentSession.Size = new System.Drawing.Size(246, 139);
            this.currentSession.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 170);
            this.Controls.Add(this.currentSession);
            this.Controls.Add(this.isWatching);
            this.Name = "MainForm";
            this.Text = "NightLight Autouploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isWatching;
        private System.Windows.Forms.ListBox currentSession;
    }
}