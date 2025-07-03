namespace pacman
{
    partial class BoardGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoardGame));
            mainMap = new PictureBox();
            textBox1 = new TextBox();
            scoreCounter = new TextBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            readyLabel = new Label();
            scaterModeTimer = new System.Windows.Forms.Timer(components);
            leftLivesText = new Label();
            smoothApperanceTimer = new System.Windows.Forms.Timer(components);
            frightenedModeTimer = new System.Windows.Forms.Timer(components);
            eatenModeTimer = new System.Windows.Forms.Timer(components);
            victoryLabel = new Label();
            chaseModeTimer = new System.Windows.Forms.Timer(components);
            inkyTimer = new System.Windows.Forms.Timer(components);
            clydeTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)mainMap).BeginInit();
            SuspendLayout();
            // 
            // mainMap
            // 
            mainMap.BackColor = Color.Black;
            mainMap.Location = new Point(0, 192);
            mainMap.Name = "mainMap";
            mainMap.Size = new Size(840, 900);
            mainMap.TabIndex = 0;
            mainMap.TabStop = false;
            mainMap.Paint += mainMap_Paint;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.ActiveCaptionText;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("BankGothic Md BT", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.Menu;
            textBox1.Location = new Point(331, 40);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(180, 131);
            textBox1.TabIndex = 1;
            textBox1.Text = "HIGH SCORE 10000";
            // 
            // scoreCounter
            // 
            scoreCounter.BackColor = SystemColors.ActiveCaptionText;
            scoreCounter.BorderStyle = BorderStyle.None;
            scoreCounter.Enabled = false;
            scoreCounter.Font = new Font("BankGothic Md BT", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scoreCounter.ForeColor = SystemColors.Menu;
            scoreCounter.Location = new Point(96, 40);
            scoreCounter.Multiline = true;
            scoreCounter.Name = "scoreCounter";
            scoreCounter.ReadOnly = true;
            scoreCounter.Size = new Size(184, 78);
            scoreCounter.TabIndex = 2;
            scoreCounter.Text = "1UP 0";
            scoreCounter.TextAlign = HorizontalAlignment.Right;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 10;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // readyLabel
            // 
            readyLabel.AutoSize = true;
            readyLabel.BackColor = Color.Transparent;
            readyLabel.Font = new Font("BankGothic Md BT", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            readyLabel.ForeColor = Color.Yellow;
            readyLabel.Location = new Point(70, 673);
            readyLabel.Name = "readyLabel";
            readyLabel.Size = new Size(717, 50);
            readyLabel.TabIndex = 3;
            readyLabel.Text = "PRESS SPACE TO START!";
            readyLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scaterModeTimer
            // 
            scaterModeTimer.Interval = 5000;
            scaterModeTimer.Tick += scaterMode_Tick;
            // 
            // leftLivesText
            // 
            leftLivesText.AutoSize = true;
            leftLivesText.Font = new Font("BankGothic Md BT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            leftLivesText.ForeColor = SystemColors.Menu;
            leftLivesText.Location = new Point(23, 1113);
            leftLivesText.Name = "leftLivesText";
            leftLivesText.Size = new Size(154, 34);
            leftLivesText.TabIndex = 4;
            leftLivesText.Text = "Lives: 4";
            // 
            // smoothApperanceTimer
            // 
            smoothApperanceTimer.Interval = 50;
            // 
            // frightenedModeTimer
            // 
            frightenedModeTimer.Interval = 4000;
            frightenedModeTimer.Tick += frightenedModeTimer_Tick;
            // 
            // eatenModeTimer
            // 
            eatenModeTimer.Interval = 4000;
            eatenModeTimer.Tick += eatenModeTimer_Tick;
            // 
            // victoryLabel
            // 
            victoryLabel.AutoSize = true;
            victoryLabel.Font = new Font("BankGothic Md BT", 22.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            victoryLabel.ForeColor = Color.Yellow;
            victoryLabel.Location = new Point(29, 673);
            victoryLabel.Name = "victoryLabel";
            victoryLabel.Size = new Size(804, 62);
            victoryLabel.TabIndex = 5;
            victoryLabel.Text = "YOU ARE THE WINNER!";
            victoryLabel.Visible = false;
            // 
            // chaseModeTimer
            // 
            chaseModeTimer.Interval = 20000;
            chaseModeTimer.Tick += chaseModeTimer_Tick;
            // 
            // inkyTimer
            // 
            inkyTimer.Interval = 8000;
            inkyTimer.Tick += inkyTimer_Tick;
            // 
            // clydeTimer
            // 
            clydeTimer.Interval = 12000;
            clydeTimer.Tick += clydeTimer_Tick;
            // 
            // BoardGame
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(845, 1340);
            Controls.Add(victoryLabel);
            Controls.Add(leftLivesText);
            Controls.Add(readyLabel);
            Controls.Add(scoreCounter);
            Controls.Add(textBox1);
            Controls.Add(mainMap);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "BoardGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pacman";
            KeyDown += BoardGame_KeyDown;
            ((System.ComponentModel.ISupportInitialize)mainMap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox mainMap;
        private TextBox textBox1;
        private TextBox scoreCounter;
        private System.Windows.Forms.Timer gameTimer;
        private Label readyLabel;
        private System.Windows.Forms.Timer scaterModeTimer;
        private Label leftLivesText;
        private System.Windows.Forms.Timer smoothApperanceTimer;
        private System.Windows.Forms.Timer frightenedModeTimer;
        private System.Windows.Forms.Timer eatenModeTimer;
        private Label victoryLabel;
        private System.Windows.Forms.Timer chaseModeTimer;
        private System.Windows.Forms.Timer inkyTimer;
        private System.Windows.Forms.Timer clydeTimer;
    }
}