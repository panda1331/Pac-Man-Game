namespace pacman.ui
{
    partial class GameOver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOver));
            label1 = new Label();
            gameOverTimer = new System.Windows.Forms.Timer(components);
            smoothApperanceTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("BankGothic Md BT", 28.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(152, 588);
            label1.Name = "label1";
            label1.Size = new Size(545, 79);
            label1.TabIndex = 0;
            label1.Text = "GAME OVER";
            // 
            // gameOverTimer
            // 
            gameOverTimer.Interval = 3000;
            // 
            // smoothApperanceTimer
            // 
            smoothApperanceTimer.Interval = 50;
            smoothApperanceTimer.Tick += smoothApperanceTimer_Tick;
            // 
            // GameOver
            // 
            AutoScaleDimensions = new SizeF(45F, 67F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(845, 1340);
            Controls.Add(label1);
            Font = new Font("BankGothic Md BT", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.Menu;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(10, 6, 10, 6);
            Name = "GameOver";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pacman";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.Windows.Forms.Timer gameOverTimer;
        private System.Windows.Forms.Timer smoothApperanceTimer;
    }
}