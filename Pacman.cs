namespace pacman.Logic;

public class Pacman : MovementLogic, IMovable
{
    public readonly MovementLogic _movementLogic;
    public float X { get; set; }
    public float Y { get; set; }
    public float Speed { get; set; } = 2;
    public Direction CurrentDirection { get; set; } = Direction.Left;
    public Direction NextDirection { get; set; } = Direction.Left;

    public bool isEatingMode = true;
    public int _numOfLives = 4;
        
    
    public Pacman(MovementLogic movementLogic)
    {
        _movementLogic = movementLogic;
    }
    
    public void Move(Map map)
    {   
        if (CurrentDirection != NextDirection)
        {
            if (_movementLogic.IsAbleToChangeDirection(map, NextDirection, X, Y))
            {
                CurrentDirection = NextDirection;
            }
        }
        
        float targetX = X, targetY = Y;
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

    
    public void Draw(Graphics g, Map map)
    {
        RectangleF rect = new RectangleF(X, Y, map.cellSize + 2, map.cellSize + 2);
        
        if (CurrentDirection == Direction.Left)
        {
            g.FillPie(Brushes.Yellow, rect, -135, 270);
        }
        else if (CurrentDirection == Direction.Right)
        {
            g.FillPie(Brushes.Yellow, rect, 45, 270);
        }
        else if (CurrentDirection == Direction.Up)
        {
            g.FillPie(Brushes.Yellow, rect, -45, 270);
        }
        else if (CurrentDirection == Direction.Down)
        {
            g.FillPie(Brushes.Yellow, rect, 135, 270);
        }
    }
}
