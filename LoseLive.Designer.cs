namespace pacman.ui
{
    partial class LoseLive
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoseLive));
            textLivesLeft = new Label();
            loseLiveTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // textLivesLeft
            // 
            textLivesLeft.AutoSize = true;
            textLivesLeft.Font = new Font("BankGothic Md BT", 22.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textLivesLeft.Location = new Point(186, 588);
            textLivesLeft.Name = "textLivesLeft";
            textLivesLeft.Size = new Size(477, 62);
            textLivesLeft.TabIndex = 0;
            textLivesLeft.Text = "3 LIVES LEFT";
            textLivesLeft.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loseLiveTimer
            // 
            loseLiveTimer.Interval = 3000;
            // 
            // LoseLive
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.stars_background;
            ClientSize = new Size(845, 1340);
            Controls.Add(textLivesLeft);
            ForeColor = SystemColors.Menu;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoseLive";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoseGame";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label textLivesLeft;
        private System.Windows.Forms.Timer loseLiveTimer;
    }
}