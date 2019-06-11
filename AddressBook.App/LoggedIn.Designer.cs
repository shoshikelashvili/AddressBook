namespace AddressBook.App
{
    partial class LoggedIn
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
            this.WelcomeScreen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WelcomeScreen
            // 
            this.WelcomeScreen.AutoSize = true;
            this.WelcomeScreen.Location = new System.Drawing.Point(189, 35);
            this.WelcomeScreen.Name = "WelcomeScreen";
            this.WelcomeScreen.Size = new System.Drawing.Size(98, 13);
            this.WelcomeScreen.TabIndex = 0;
            this.WelcomeScreen.Text = "Welcome Message";
            // 
            // LoggedIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.WelcomeScreen);
            this.Name = "LoggedIn";
            this.Text = "LoggedIn";
            this.Load += new System.EventHandler(this.LoggedIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeScreen;
    }
}