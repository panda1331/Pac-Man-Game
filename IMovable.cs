namespace pacman.Logic;

public interface IMovable
{
    float X { get; set; }
    float Y { get; set; }
    float Speed { get; set; }
    Direction CurrentDirection { get; set; }
}