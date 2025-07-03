namespace pacman.Logic;

public class MovementLogic
{
    public virtual bool IsAbleToChangeDirection(Map map, Direction newDirection, float x, float y)
    {
        
        int cellX = (int)(x / map.cellSize);
        int cellY = (int)(y / map.cellSize);

        switch (newDirection)
        {
            case Direction.Up:    return map.CheckBoundaries(cellX, cellY - 1);
            case Direction.Down:  return map.CheckBoundaries(cellX, cellY + 1);
            case Direction.Left:  return map.CheckBoundaries(cellX - 1, cellY);
            case Direction.Right: return map.CheckBoundaries(cellX + 1, cellY);
        }
        return false;
    }

    public virtual bool IsPossibleMovement(Map map, float targetX, float targetY)
    {
        int leftCell = (int)(targetX / map.cellSize);
        int rightCell = (int)((targetX + map.cellSize - 1) / map.cellSize);
        int topCell = (int)(targetY / map.cellSize);
        int bottomCell = (int)((targetY + map.cellSize - 1) / map.cellSize);

        if (!map.CheckBoundaries(leftCell, topCell) ||
            !map.CheckBoundaries(rightCell, topCell) ||
            !map.CheckBoundaries(leftCell, bottomCell) ||
            !map.CheckBoundaries(rightCell, bottomCell))
        {
            return false;
        }
        return true;
    }
    public virtual void StopAtGrid(Map map, IMovable movable)
    {
        movable.X = (int)(movable.X / map.cellSize) * map.cellSize;
        movable.Y = (int)(movable.Y / map.cellSize) * map.cellSize;
    }
}
