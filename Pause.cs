using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman;

public partial class Pause : Form
{
    BoardGame currBoardGameWindow;
    MainMenu currMenu;
    public Pause(BoardGame boardGame, MainMenu menu)
    {
        InitializeComponent();
        this.currBoardGameWindow = boardGame;
        this.currMenu = menu;
    }

    private void resumeBtn_Click(object sender, EventArgs e)
    {
        currBoardGameWindow.Show();
        this.Hide();
    }

    private void quitBtn_Click(object sender, EventArgs e)
    {
        currMenu.Show();
        this.Hide();
    }
}
