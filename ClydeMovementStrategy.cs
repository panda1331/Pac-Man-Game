namespace pacman.Logic;

public class ClydeMovementStrategy : GhostMovementStrategy
{
    private readonly MovementLogic _movementLogic = new MovementLogic();

    public override void ChaseMode(Ghost ghost, Pacman pacman, Map map) 
    {
        float distance = CalculateDistance(new PointF(ghost.X, ghost.Y), new PointF(pacman.X, pacman.Y));
        if (distance > 8 * map.cellSize)
        {
            ghost.TargetX = pacman.X;
            ghost.TargetY = pacman.Y;
        }
        else
        {
            ghost.TargetX = 0 * map.cellSize; 
            ghost.TargetY = map.Board.GetLength(0) * map.cellSize;
        }
        GetToCurrentTarget(ghost, map);
    }
}
