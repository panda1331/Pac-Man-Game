using pacman.Logic;
using pacman.ui;
using System.Drawing.Text;
using System.Media;
using System.Security.Permissions;

namespace pacman;

public partial class BoardGame : Form
{
    private Pause _pause;
    private MainMenu _menu;

    private Map _map = new Map();
    private Pacman _pacman;
    public List<Ghost> _ghosts;
    private readonly MovementLogic _movementLogic;

    public bool _isEnergiezed = false;
    private int _dotScore = 0;
    private int _energyScore = 0;
    private int _totalScore = 0;
    private int _inkysDots = 0;
    private int _clydesDots = 0;

    public BoardGame(MainMenu menu)
    {
        InitializeComponent();
        mainMap.Invalidate();

        _movementLogic = new MovementLogic();
        _pause = new Pause(this, menu);
        _pacman = new Pacman(_movementLogic);
        _ghosts = new List<Ghost>()
        {
            new Blinky(_movementLogic),
            new Pinky(_movementLogic),
            new Inky(_movementLogic),
            new Clyde(_movementLogic)
        };

        this._menu = menu;
        gameTimer.Tick += gameTimer_Tick;

        foreach (Ghost ghost in _ghosts)
        {
            ghost.BoardGame = this;
        }
        SetUpUI();
    }


    public void SetUpUI()
    {
        mainMap.Width = _map.Board.GetLength(1) * _map.cellSize;
        mainMap.Height = _map.Board.GetLength(0) * _map.cellSize;
        _pacman.X = 13 * _map.cellSize + _map.cellSize / 2;
        _pacman.Y = 22 * _map.cellSize;
        SetGhostsStarts();
        SetGhostsTargets();
    }
    private void SetGhostsStarts()
    {
        _ghosts[0].X = 13 * _map.cellSize;
        _ghosts[0].Y = 11 * _map.cellSize;
        _ghosts[1].X = 14 * _map.cellSize;
        _ghosts[1].Y = 11 * _map.cellSize;
        _ghosts[2].X = 11 * _map.cellSize;
        _ghosts[2].Y = 14 * _map.cellSize;
        _ghosts[3].X = 16 * _map.cellSize;
        _ghosts[3].Y = 14 * _map.cellSize;
    }
    private void SetGhostsTargets()
    {
        _ghosts[0].TargetX = 25 * _map.cellSize;
        _ghosts[0].TargetY = 0;
        _ghosts[1].TargetX = 3 * _map.cellSize;
        _ghosts[1].TargetY = 0;
        _ghosts[2].TargetX = 25 * _map.cellSize;
        _ghosts[2].TargetY = 30 * _map.cellSize;
        _ghosts[3].TargetX = 3 * _map.cellSize;
        _ghosts[3].TargetY = 30 * _map.cellSize;
    }
    private void BoardGame_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up: _pacman.NextDirection = Direction.Up; break;
            case Keys.Down: _pacman.NextDirection = Direction.Down; break;
            case Keys.Left: _pacman.NextDirection = Direction.Left; break;
            case Keys.Right: _pacman.NextDirection = Direction.Right; break;
            case Keys.Escape: EscBtnPressed(); break;
            case Keys.Space: SpaceBtnPressed(); break;
        }
    }
    private void EscBtnPressed()
    {
        _pause.Show();
        gameTimer.Stop();
        scaterModeTimer.Stop();
        chaseModeTimer.Stop();
        frightenedModeTimer.Stop();
        eatenModeTimer.Stop();
        inkyTimer.Stop();
        clydeTimer.Stop();
        readyLabel.Visible = true;
        this.Hide();
    }
    private void SpaceBtnPressed()
    {
        gameTimer.Start();
        scaterModeTimer.Start();
        inkyTimer.Start();
        clydeTimer.Start();
        readyLabel.Visible = false;
    }

    public static void DrawBoard(Graphics g, Map map)
    {
        for (int y = 0; y < map.Board.GetLength(0); ++y)
        {
            for (int x = 0; x < map.Board.GetLength(1); ++x)
            {
                switch (map.Board[y, x])
                {
                    case 1:
                        DrawWalls(g, map, x, y);
                        break;
                    case 2:
                        RectangleF dot = new RectangleF(x * map.cellSize + 10, y * map.cellSize + 10, map.cellSize - 20, map.cellSize - 20);
                        g.FillEllipse(Brushes.LightYellow, dot);
                        break;
                    case 3:
                        RectangleF energy = new RectangleF(x * map.cellSize + 5, y * map.cellSize + 5, map.cellSize - 8, map.cellSize - 8);
                        g.FillEllipse(Brushes.White, energy);
                        break;
                    case 4:
                        RectangleF gate = new RectangleF(x * map.cellSize, y * map.cellSize + map.cellSize / 2, map.cellSize, map.cellSize / 4);
                        g.FillRectangle(Brushes.White, gate);
                        break;
                }
            }
        }
    }
    private void mainMap_Paint(object sender, PaintEventArgs e)
    {
        DrawBoard(e.Graphics, _map);
        _pacman.Draw(e.Graphics, _map);
        
        foreach (Ghost ghost in _ghosts)
        {
            ghost.Draw(e.Graphics, _map);
        }

    }
    private static void DrawWalls(Graphics g, Map map, int x, int y)
    {
        bool hasTop = y > 0 && map.Board[y - 1, x] == 1;
        bool hasBottom = y < map.Board.GetLength(0) - 1 && map.Board[y + 1, x] == 1;
        bool hasLeft = x > 0 && map.Board[y, x - 1] == 1;
        bool hasRight = x < map.Board.GetLength(1) - 1 && map.Board[y, x + 1] == 1;

        if (hasTop && hasBottom && hasRight && hasLeft)
        {
            if (map.Board[y + 1, x - 1] == 2 || map.Board[y + 1, x - 1] == 0)
            {
                RectangleF archtopright = new RectangleF(x * map.cellSize + 2, y * map.cellSize + map.cellSize / 2 + 3, map.cellSize / 2, map.cellSize);
                g.DrawArc(new Pen(Brushes.Blue, 5), archtopright, 270, 90);
            }
            else if (map.Board[y + 1, x + 1] == 2 || map.Board[y + 1, x + 1] == 0)
            {
                RectangleF archtopleft = new RectangleF(x * map.cellSize + map.cellSize / 2 + 2, y * map.cellSize + map.cellSize / 2 + 3, map.cellSize / 2, map.cellSize);
                g.DrawArc(new Pen(Brushes.Blue, 5), archtopleft, 180, 90);
            }
            else if (map.Board[y - 1, x - 1] == 2 || map.Board[y - 1, x - 1] == 0)
            {
                RectangleF archbottomright = new RectangleF(x * map.cellSize + 2, y * map.cellSize - map.cellSize / 2, map.cellSize / 2, map.cellSize);
                g.DrawArc(new Pen(Brushes.Blue, 5), archbottomright, 0, 90);
            }
            else if (map.Board[y - 1, x + 1] == 2 || map.Board[y - 1, x + 1] == 0)
            {
                RectangleF archbottomleft = new RectangleF(x * map.cellSize + map.cellSize / 2 + 2, y * map.cellSize - map.cellSize / 2, map.cellSize / 2, map.cellSize);
                g.DrawArc(new Pen(Brushes.Blue, 5), archbottomleft, 90, 90);
            }
        }
        else if (!hasTop && !hasLeft && hasBottom && hasRight)
        {
            RectangleF archtopleft = new RectangleF(x * map.cellSize + map.cellSize / 2 + 2, y * map.cellSize + map.cellSize / 2 + 3, map.cellSize / 2, map.cellSize);
            g.DrawArc(new Pen(Brushes.Blue, 5), archtopleft, 180, 90);
        }
        else if (!hasTop && !hasRight && hasBottom && hasLeft)
        {
            RectangleF archtopright = new RectangleF(x * map.cellSize + 2, y * map.cellSize + map.cellSize / 2 + 3, map.cellSize / 2, map.cellSize);
            g.DrawArc(new Pen(Brushes.Blue, 5), archtopright, 270, 90);
        }
        else if (!hasBottom && !hasLeft && hasTop && hasRight)
        {
            RectangleF archbottomleft = new RectangleF(x * map.cellSize + map.cellSize / 2 + 2, y * map.cellSize - map.cellSize / 2, map.cellSize / 2, map.cellSize);
            g.DrawArc(new Pen(Brushes.Blue, 5), archbottomleft, 90, 90);
        }
        else if (!hasBottom && !hasRight && hasTop && hasLeft)
        {
            RectangleF archbottomright = new RectangleF(x * map.cellSize + 2, y * map.cellSize - map.cellSize / 2, map.cellSize / 2, map.cellSize);
            g.DrawArc(new Pen(Brushes.Blue, 5), archbottomright, 0, 90);
        }
        else if (!hasTop)
        {
            RectangleF wallTop = new RectangleF(x * map.cellSize - 5, y * map.cellSize + map.cellSize / 2, map.cellSize + 15, 5);
            g.FillRectangle(Brushes.Blue, wallTop);
        }
        else if (!hasBottom)
        {
            RectangleF wallBottom = new RectangleF(x * map.cellSize - 5, y * map.cellSize + map.cellSize / 2, map.cellSize + 15, 5);
            g.FillRectangle(Brushes.Blue, wallBottom);
        }
        else if (!hasLeft)
        {
            RectangleF wallLeft = new RectangleF(x * map.cellSize + map.cellSize / 2, y * map.cellSize, 5, map.cellSize);
            g.FillRectangle(Brushes.Blue, wallLeft);
        }
        else if (!hasRight)
        {
            RectangleF wallLeft = new RectangleF(x * map.cellSize + map.cellSize / 2, y * map.cellSize, 5, map.cellSize);
            g.FillRectangle(Brushes.Blue, wallLeft);
        }
    }


    private void gameTimer_Tick(object sender, EventArgs e)
    {
        int cellX = (int)(_pacman.X / _map.cellSize);
        int cellY = (int)(_pacman.Y / _map.cellSize);

        if (_map.CheckBoundaries(cellX, cellY))
        {
            _pacman.Move(_map);
        }
        if (_inkysDots == 300 && (_ghosts[2].X >= 11 * _map.cellSize && _ghosts[2].X <= 16 * _map.cellSize && _ghosts[2].Y == 14 * _map.cellSize))
        {
            _ghosts[2].X = 14 * _map.cellSize;
            _ghosts[2].Y = 11 * _map.cellSize;
            inkyTimer.Stop();
        }
        if (_clydesDots == 600  && (_ghosts[3].X >= 11 * _map.cellSize && _ghosts[3].X <= 16 * _map.cellSize && _ghosts[3].Y == 14 * _map.cellSize))
        {
            _ghosts[3].X = 14 * _map.cellSize;
            _ghosts[3].Y = 11 * _map.cellSize;
            clydeTimer.Stop();
        }

        foreach (Ghost ghost in _ghosts)
        {
            if (_map.CheckBoundaries((int)(ghost.X / _map.cellSize), (int)(ghost.Y / _map.cellSize)))
            {
                ghost.Move(_pacman, _map);
            }
            if (!_isEnergiezed)
            {
                if (Math.Abs(_pacman.X - ghost.X) < _map.cellSize && Math.Abs(_pacman.Y - ghost.Y) < _map.cellSize)
                {
                    LoseLive();
                    break;
                }
            }
            else
            {
                if (Math.Abs(_pacman.X - ghost.X) < _map.cellSize && Math.Abs(_pacman.Y - ghost.Y) < _map.cellSize)
                {
                    scaterModeTimer.Stop();
                    chaseModeTimer.Stop();
                    frightenedModeTimer.Stop();

                    if (!ghost._isGhostMeetPacman)
                    {
                        ghost._isGhostMeetPacman = true;
                    }

                    ghost.CurrentMode = GhostMode.Eaten;
                    ghost.Speed = 2.8f;
                    eatenModeTimer.Start();
                }
            }
        }

        CountScore(cellX, cellY);
        mainMap.Invalidate();
    }

    private void scaterMode_Tick(object sender, EventArgs e)
    {
        scaterModeTimer.Stop();
        _isEnergiezed = false;

        foreach (Ghost ghost in _ghosts)
        {
            ghost.CurrentMode = GhostMode.Chase;
            ghost.Speed = 1.6f;
        }

        chaseModeTimer.Start();
        mainMap.Invalidate();
    }
    private void chaseModeTimer_Tick(object sender, EventArgs e)
    {
        chaseModeTimer.Stop();
        _isEnergiezed = false;

        foreach (Ghost ghost in _ghosts)
        {
            ghost.CurrentMode = GhostMode.Scater;
            ghost.Speed = 1.4f;
        }

        SetGhostsTargets();
        scaterModeTimer.Start();
        mainMap.Invalidate();
    }
    private void frightenedModeTimer_Tick(object sender, EventArgs e)
    {
        frightenedModeTimer.Stop();
        _isEnergiezed = false;

        foreach (Ghost ghost in _ghosts)
        {            
            ghost.CurrentMode = GhostMode.Scater;
            ghost.Speed = 1.4f;
        }

        SetGhostsTargets();
        scaterModeTimer.Start();
        mainMap.Invalidate();
    }

    private void eatenModeTimer_Tick(object sender, EventArgs e)
    {
        eatenModeTimer.Stop();
        _isEnergiezed = false;
        foreach (Ghost ghost in _ghosts)
        {
            ghost.CurrentMode = GhostMode.Scater;
            ghost._isGhostMeetPacman = false;
            ghost.Speed = 1.4f;
        }

        SetGhostsTargets();
        scaterModeTimer.Start();
        mainMap.Invalidate();
    }


    private void inkyTimer_Tick(object sender, EventArgs e)
    {
        inkyTimer.Stop();
        _ghosts[2].X = 14 * _map.cellSize;
        _ghosts[2].Y = 11 * _map.cellSize;
    }

    private void clydeTimer_Tick(object sender, EventArgs e)
    {
        clydeTimer.Stop();
        _ghosts[3].X = 14 * _map.cellSize;
        _ghosts[3].Y = 11 * _map.cellSize;
    }

    private async void CountScore(int x, int y)
    {
        if (_map.Board[y, x] == 2)
        {
            _pacman.isEatingMode = true;
            _dotScore += 10;
            _inkysDots += 10;
            _clydesDots += 10;
            _totalScore += 10;
            _map.Board[y, x] = 0;

            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            player.URL = @"D:\bsuir\pacman\pacman\pacman\Resources\eating_dots.mp3";
            player.settings.volume = 10;
            player.controls.play();
        }
        else if (_map.Board[y, x] == 3)
        {
            _pacman.isEatingMode = true;
            _energyScore += 50;
            _totalScore += 50;
            _isEnergiezed = true;
            foreach (Ghost ghost in _ghosts)
            {
                ghost.CurrentMode = GhostMode.Frightened;
                ghost.Speed = 0.8f;
            }
            _map.Board[y, x] = 0;
            frightenedModeTimer.Start();
            scaterModeTimer.Stop();
            chaseModeTimer.Stop();
            eatenModeTimer.Stop();

            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            player.URL = @"D:\bsuir\pacman\pacman\pacman\Resources\get_bonus.mp3";
            player.settings.volume = 10;
            player.controls.play();
        }
        foreach (Ghost ghost in _ghosts)
        {
            if (ghost._isGhostMeetPacman)
            {
                _totalScore += 200;
                ghost._isGhostMeetPacman = false;
            }
        }
        _pacman.isEatingMode = false;

        scoreCounter.Text = $"1 UP {_totalScore}";
        if (_dotScore == 2400 && _energyScore == 200)
        {
            gameTimer.Stop();
            scaterModeTimer.Stop();
            frightenedModeTimer.Stop();
            chaseModeTimer.Stop();
            eatenModeTimer.Stop();
            inkyTimer.Stop();
            clydeTimer.Stop();

            victoryLabel.Visible = true;
            await Task.Delay(3000);

            _menu.Show();
            this.Close();
        }
    }
    private void ResetGame()
    {
        _pacman.X = 13 * _map.cellSize + _map.cellSize / 2;
        _pacman.Y = 22 * _map.cellSize;
        _pacman.CurrentDirection = Direction.Left;
        _pacman.NextDirection = Direction.Left;
        _inkysDots = 0;
        _clydesDots = 0;

        foreach (Ghost ghost in _ghosts)
        {
            ghost.CurrentDirection = Direction.Left;
            ghost.CurrentMode = GhostMode.Scater;
            ghost.Speed = 1.4f;
        }

        SetGhostsStarts();
        SetGhostsTargets();

    }
    public void LoseLive()
    {
        _pacman._numOfLives -= 1;
        leftLivesText.Text = $"LIVES: {_pacman._numOfLives}";


        gameTimer.Stop();
        scaterModeTimer.Stop();
        frightenedModeTimer.Stop();
        chaseModeTimer.Stop();
        eatenModeTimer.Stop();
        inkyTimer.Stop();
        clydeTimer.Stop();

        LoseLive loseLive = new LoseLive(_pacman);

        if (_pacman._numOfLives <= 0)
        {
            GameOver();
        }
        else
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            player.URL = @"D:\bsuir\pacman\pacman\pacman\Resources\lose_live.mp3";
            player.settings.volume = 10;
            player.controls.play();

            loseLive.ShowDialog();
            readyLabel.Show();
            ResetGame();
        }

    }
    public void GameOver()
    {
        gameTimer.Stop();
        scaterModeTimer.Stop();
        frightenedModeTimer.Stop();
        chaseModeTimer.Stop();
        eatenModeTimer.Stop();
        inkyTimer.Stop();
        clydeTimer.Stop();

        GameOver gameOver = new GameOver(_menu);
        gameOver.Show();

        this.Close();
    }
}
