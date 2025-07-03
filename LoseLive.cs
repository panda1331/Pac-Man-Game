using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using pacman;
using pacman.Logic;
namespace pacman.ui;


public partial class LoseLive : Form
{
    public LoseLive(Pacman pacman)
    {
        InitializeComponent();
        loseLiveTimer.Tick += (s, e) =>
        {
            loseLiveTimer.Stop();
            this.Close();
        };

        this.Load += (s, e) =>
        {
            loseLiveTimer.Start();
            if (pacman._numOfLives == 1)
                textLivesLeft.Text = $"{pacman._numOfLives} LIVE LEFT";
            else 
                textLivesLeft.Text = $"{pacman._numOfLives} LIVES LEFT";
        };
    }
}
