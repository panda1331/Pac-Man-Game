using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman.ui
{
    public partial class GameOver : Form
    {
        public GameOver(MainMenu mainMenu)
        {
            InitializeComponent();

            gameOverTimer.Tick += (s, e) =>
            {
                gameOverTimer.Stop();
                this.Close();
                mainMenu.Show();
            };

            this.Load += (s, e) =>
            {
                smoothApperanceTimer.Start();
                gameOverTimer.Start();
            };
        }

        private void smoothApperanceTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            } 
            else
            {
                smoothApperanceTimer.Stop();
            }
        }
    }
}
