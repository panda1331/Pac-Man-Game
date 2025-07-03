namespace pacman.Logic;

public abstract class Ghost : IMovable
{
    private readonly MovementLogic _movementLogic;
    protected IGhostMovementStrategy _movementStrategy;
    protected IGhostDrawing _drawStrategy;

    public float X { get; set; }
    public float Y { get; set; }
    public float TargetX { get; set; }
    public float TargetY { get; set; }
    public float Speed { get; set; } = 1.4f;

    public Direction CurrentDirection { get; set; } = Direction.Left;
    public Direction NextDirection { get; set; } = Direction.Left;
    public GhostMode CurrentMode { get; set; } = GhostMode.Scater;
    public bool _isGhostMeetPacman = false;
    public BoardGame BoardGame { get; set; }

    public Ghost(MovementLogic movementLogic)
    {
        _movementLogic = movementLogic;
    }

    public void Move(Pacman pacman,Map map)
    {
        _movementStrategy.CalculateDirection(this, pacman, map); 
        
        float targetX = X;
        float targetY = Y;
        
        switch (CurrentDirection)
        {
            case Direction.Up:
                targetY -= Speed;
                break;
            case Direction.Down:
                targetY += Speed;
                break;
            case Direction.Left:
                targetX -= Speed;
                break;
            case Direction.Right:
                targetX += Speed;
                break;
        }
        
        if (_movementLogic.IsPossibleMovement(map, targetX, targetY))
        {
            X = targetX;
            Y = targetY;
           
            if (Y / map.cellSize == 14 && X < 0)
            {
                X = (map.Board.GetLength(1) - 1) * map.cellSize;
            }
            else if (Y / map.cellSize == 14 && X >= ((map.Board.GetLength(1) - 1) * map.cellSize))
            {
                X = 0;
            }
        }
        else
        {
            _movementLogic.StopAtGrid(map, this);
        }
        
    }

    public void Draw(Graphics g, Map map) => _drawStrategy.Draw(g, this, map);
}