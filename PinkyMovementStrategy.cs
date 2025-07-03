namespace pacman.Logic;

public class PinkyMovementStrategy : GhostMovementStrategy
{
    private readonly MovementLogic _movementLogic = new MovementLogic();
    public override void ChaseMode(Ghost ghost, Pacman pacman, Map map)
    {
        int offsetX = 0, offsetY = 0;
        switch (pacman.CurrentDirection)
        {
            case Direction.Up:
                offsetX = -4;
                offsetY = -4;
                break;
            case Direction.Down:
                offsetY = 4;
                break;
            case Direction.Left:
                offsetX = -4;
                break;
            case Direction.Right:
                offsetX = 4;
                break;
        }
        
        ghost.TargetX = pacman.X + offsetX * map.cellSize;
        ghost.TargetY = pacman.Y + offsetY * map.cellSize;
        GetToCurrentTarget(ghost, map);
    }
}
