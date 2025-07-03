namespace pacman.Logic;

public class Inky : Ghost
{
    public Inky(MovementLogic movementLogic) : base(movementLogic)
    {
        _movementStrategy = new InkyMovementStrategy();
        _drawStrategy = new GhostDrawer("pacman.Resources.inky.png", "pacman.Resources.frightened_ghost.png");
    }
}
