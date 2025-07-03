using pacman.Logic;

namespace pacman
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            smoothApperanceYimer.Start();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            BoardGame boardGame = new BoardGame(this);
            boardGame.Show();
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void smoothApperanceYimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.0)
            {
                this.Opacity += 0.05;
            }
            else
            {
                smoothApperanceYimer.Stop();
            }
        }
    }
}
