namespace pacman.Logic;
public abstract class GhostMovementStrategy : IGhostMovementStrategy
{
    BoardGame _boardGame;
    
    private readonly MovementLogic _movementLogic = new MovementLogic();

    public void CalculateDirection(Ghost ghost, Pacman pacman, Map map)
    {
        switch (ghost.CurrentMode)
        {
            case GhostMode.Scater:
                ScaterMode(ghost, map);
                break;
            case GhostMode.Chase:
                ChaseMode(ghost, pacman, map);
                break;
            case GhostMode.Frightened:
                FrightenedMode(ghost, map);
                break;
            case GhostMode.Eaten:
                EatenMode(ghost, map);
                break;
        }
    }

    public void ScaterMode(Ghost ghost, Map map) 
    {
        GetToCurrentTarget(ghost, map);
    }

    public void FrightenedMode(Ghost ghost, Map map)
    {
        List<Direction> directions = GetPosibleDirections(ghost, map);
        if (directions.Count > 0)
        {
            ghost.CurrentDirection = directions[new Random().Next(0, directions.Count)];
        }
        ghost.TargetX = new Random().Next(-200, 900);
        ghost.TargetY = new Random().Next(-200, 900);
        GetToCurrentTarget(ghost, map);
    }

    public void EatenMode(Ghost ghost, Map map)
    {
        ghost.TargetX = 13 * map.cellSize;
        ghost.TargetY = 14  * map.cellSize;
        GetToCurrentTarget(ghost, map);
    }
    public abstract void ChaseMode(Ghost ghost, Pacman pacman, Map map);

    public void GetToCurrentTarget(Ghost ghost, Map map)
    {
        List<Direction> directions = GetPosibleDirections(ghost, map);
        
        double minDistance = double.MaxValue;
        Direction targetDirection = Direction.Up;

        foreach (Direction direction in directions)
        {
            if (_movementLogic.IsAbleToChangeDirection(map, direction, ghost.X, ghost.Y))
            {
                float currX = ghost.X;
                float currY = ghost.Y;

                switch (direction)
                {
                    case Direction.Up:
                        currY -= ghost.Speed;
                        break;
                    case Direction.Down:
                        currY += ghost.Speed;
                        break;
                    case Direction.Right:
                        currX += ghost.Speed;
                        break;
                    case Direction.Left:
                        currX -= ghost.Speed;
                        break;
                }
                double distance = (float)Math.Sqrt(Math.Pow(currX - ghost.TargetX, 2) + Math.Pow(currY - ghost.TargetY, 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetDirection = direction;
                }
            }
        }
        ghost.CurrentDirection = targetDirection;
        
    }
    private List<Direction> GetPosibleDirections(Ghost ghost, Map map)
    {
        List<Direction> directions = new List<Direction>() { Direction.Up, Direction.Down, Direction.Right, Direction.Left };
        directions.Remove(GetOppositeDirection(ghost.CurrentDirection));

        foreach (Direction direction in directions.ToList())
        {
            if (!_movementLogic.IsAbleToChangeDirection(map, direction, ghost.X, ghost.Y))
            {
                directions.Remove(direction);
            }
        }
        return directions;
    }
    public Direction GetOppositeDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up: return Direction.Down;
            case Direction.Down: return Direction.Up;
            case Direction.Left: return Direction.Right;
            case Direction.Right: return Direction.Left;
            default: return direction;
        }
    }
    protected float CalculateDistance(PointF ghostPoint, PointF targetPoint)
    {
        float difX = ghostPoint.X - targetPoint.X;
        float difY = ghostPoint.Y - targetPoint.Y;

        return (float)Math.Sqrt(difX * difX + difY * difY);
    }

}
