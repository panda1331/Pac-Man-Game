namespace pacman.Logic;

public interface IGhostMovementStrategy
{
    void CalculateDirection(Ghost ghost, Pacman pacman, Map map);
    void ChaseMode( Ghost ghost, Pacman pacman, Map map);
}
