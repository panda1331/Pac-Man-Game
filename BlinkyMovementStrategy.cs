namespace pacman.Logic;

public class BlinkyMovementStrategy : GhostMovementStrategy
{
    private readonly MovementLogic _movementLogic = new MovementLogic();

    public override void ChaseMode(Ghost ghost, Pacman pacman, Map map)
    {
        ghost.TargetX = pacman.X;
        ghost.TargetY = pacman.Y;

        GetToCurrentTarget(ghost, map);    
    }    
}
