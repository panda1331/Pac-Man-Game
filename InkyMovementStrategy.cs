namespace pacman.Logic;

public class InkyMovementStrategy : GhostMovementStrategy
{
    private readonly MovementLogic _movementLogic = new MovementLogic();

    public override void ChaseMode(Ghost ghost, Pacman pacman, Map map)
    {
        Ghost? blinky = null;
        foreach(Ghost g in ghost.BoardGame._ghosts)
        {
            if (g is Blinky)
            {
                blinky = g;
                break;
            }
        }

        PointF pacmanAhead = GetPointAhead(pacman, map);

        float vecX = pacmanAhead.X - blinky.X;
        float vecY = pacmanAhead.Y - blinky.Y;

        ghost.TargetX = pacmanAhead.X + vecX;
        ghost.TargetY = pacmanAhead.Y + vecY;

        GetToCurrentTarget(ghost, map);
    }

    private PointF GetPointAhead(Pacman pacman, Map map)
    {
        int offsetX = 0, offsetY = 0;

        switch(pacman.CurrentDirection) 
        {
            case Direction.Up:
                offsetX = -2;
                offsetY = -2;
                break;
            case Direction.Down:
                offsetY = 2;
                break;
            case Direction.Left:
                offsetX = -2;
                break ;
            case Direction.Right:
                offsetX = 2;
                break;
        }

        return new PointF(pacman.X + offsetX * map.cellSize, pacman.Y + offsetY * map.cellSize);
    }
}
