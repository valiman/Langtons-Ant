using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LangtonsAnt
{
    public enum Direction
    {
        Left,
        Right
    }
    public enum Rotation
    {
        North,
        South,
        West,
        East
    }
    public enum TileColor
    {
        White, //turn left (anticlockwise)
        Black, //turn right (clockwise)
        Red, //turn left (anticlockwise)
        Green, //turn right (clockwise)
        Blue //turn right (clockwise)
    }
    public static class TileSize
    {
        public static int X = 5;
        public static int Y = 5;
    }
}
