namespace pacman.Logic;

public class Pinky : Ghost
{
    public Pinky(MovementLogic movementLogic) : base(movementLogic)
    {
        _movementStrategy = new PinkyMovementStrategy();
        _drawStrategy = new GhostDrawer("pacman.Resources.pinky.png", "pacman.Resources.frightened_ghost.png");
    }
}

  