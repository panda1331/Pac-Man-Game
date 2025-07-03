namespace pacman.Logic;

public class Blinky : Ghost
{
    public Blinky(MovementLogic movementLogic) : base(movementLogic) 
    {
        Speed = 1.5f;
        _movementStrategy = new BlinkyMovementStrategy();
        _drawStrategy = new GhostDrawer("pacman.Resources.blinky.png", "pacman.Resources.frightened_ghost.png");
    } 
}

