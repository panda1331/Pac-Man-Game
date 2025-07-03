namespace pacman.Logic;

public class Clyde : Ghost
{
    public Clyde(MovementLogic movementLogic) : base(movementLogic)
    {
        _movementStrategy = new ClydeMovementStrategy();
        _drawStrategy = new GhostDrawer("pacman.Resources.clyde.png", "pacman.Resources.frightened_ghost.png");
    }
}
