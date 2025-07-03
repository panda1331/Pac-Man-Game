namespace pacman
{
    partial class Pause
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pause));
            resumeBtn = new Button();
            quitBtn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // resumeBtn
            // 
            resumeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resumeBtn.BackColor = Color.Yellow;
            resumeBtn.FlatStyle = FlatStyle.Flat;
            resumeBtn.Font = new Font("BankGothic Md BT", 26.1428585F);
            resumeBtn.Location = new Point(227, 583);
            resumeBtn.Name = "resumeBtn";
            resumeBtn.Size = new Size(386, 77);
            resumeBtn.TabIndex = 1;
            resumeBtn.Text = "RESUME";
            resumeBtn.UseVisualStyleBackColor = false;
            resumeBtn.Click += resumeBtn_Click;
            // 
            // quitBtn
            // 
            quitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            quitBtn.BackColor = Color.Yellow;
            quitBtn.FlatStyle = FlatStyle.Flat;
            quitBtn.Font = new Font("BankGothic Md BT", 26.1428585F);
            quitBtn.Location = new Point(227, 698);
            quitBtn.Name = "quitBtn";
            quitBtn.Size = new Size(386, 77);
            quitBtn.TabIndex = 2;
            quitBtn.Text = "QUIT";
            quitBtn.UseVisualStyleBackColor = false;
            quitBtn.Click += quitBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("BankGothic Md BT", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(214, 397);
            label1.Name = "label1";
            label1.Size = new Size(419, 101);
            label1.TabIndex = 3;
            label1.Text = "PAUSE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Pause
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.stars_background;
            ClientSize = new Size(845, 1340);
            Controls.Add(label1);
            Controls.Add(quitBtn);
            Controls.Add(resumeBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Pause";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pause";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button resumeBtn;
        private Button quitBtn;
        private Label label1;
    }
}