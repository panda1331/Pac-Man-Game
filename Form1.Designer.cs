namespace pacman
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            label1 = new Label();
            startBtn = new Button();
            exitBtn = new Button();
            smoothApperanceYimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Black;
            label1.Font = new Font("BankGothic Md BT", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(42, 342);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(764, 124);
            label1.TabIndex = 0;
            label1.Text = "PACMAN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.Yellow;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("BankGothic Md BT", 26.1428585F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startBtn.ForeColor = SystemColors.ActiveCaptionText;
            startBtn.Location = new Point(226, 629);
            startBtn.Margin = new Padding(4, 2, 4, 2);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(386, 77);
            startBtn.TabIndex = 1;
            startBtn.Text = "START";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            // 
            // exitBtn
            // 
            exitBtn.BackColor = Color.Yellow;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Font = new Font("BankGothic Md BT", 26.1428585F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitBtn.ForeColor = SystemColors.ActiveCaptionText;
            exitBtn.Location = new Point(226, 749);
            exitBtn.Margin = new Padding(4, 2, 4, 2);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(386, 77);
            exitBtn.TabIndex = 3;
            exitBtn.Text = "EXIT";
            exitBtn.UseVisualStyleBackColor = false;
            exitBtn.Click += exitBtn_Click;
            // 
            // smoothApperanceYimer
            // 
            smoothApperanceYimer.Interval = 50;
            smoothApperanceYimer.Tick += smoothApperanceYimer_Tick;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(17F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.stars_background;
            ClientSize = new Size(845, 1340);
            Controls.Add(exitBtn);
            Controls.Add(startBtn);
            Controls.Add(label1);
            Font = new Font("BankGothic Md BT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "MainMenu";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pacman";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button startBtn;
        private Button exitBtn;
        private System.Windows.Forms.Timer smoothApperanceYimer;
    }
}
