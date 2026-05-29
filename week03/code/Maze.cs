using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message 
    /// "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        var dirs = _mazeMap[(_currX, _currY)];
        if (!dirs[0])
            throw new InvalidOperationException("Can't go that way!");

        _currX -= 1;
    }

    /// <summary>
    /// Check to see if you can move right. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message 
    /// "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        var dirs = _mazeMap[(_currX, _currY)];
        if (!dirs[1])
            throw new InvalidOperationException("Can't go that way!");

        _currX += 1;
    }

    /// <summary>
    /// Check to see if you can move up. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message 
    /// "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        var dirs = _mazeMap[(_currX, _currY)];
        if (!dirs[2])
            throw new InvalidOperationException("Can't go that way!");

        _currY += 1;
    }

    /// <summary>
    /// Check to see if you can move down. If you can, then move. If you
    /// can't move, throw an InvalidOperationException with the message 
    /// "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        var dirs = _mazeMap[(_currX, _currY)];
        if (!dirs[3])
            throw new InvalidOperationException("Can't go that way!");

        _currY -= 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
