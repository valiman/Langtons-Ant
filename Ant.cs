using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LangtonsAnt
{
    public class Ant
    {
        private Point location;
        private Direction direction;
        private Rotation rotation;
        private List<Tile> tileList;
        private Map map;

        public Ant(Map map, List<Tile> tileList, Point startLocation)
        {
            this.location = startLocation;
            this.tileList = tileList;
            this.map = map;

            rotation = Rotation.East;
        }

        public void MoveDirection()
        {
            ManageDirection();
            if (direction == Direction.Left)
            {
                switch (rotation)
                {
                    case Rotation.East:
                        location.Y -= TileSize.X;
                        rotation = Rotation.North; // we're now pointing North.
                        break;
                    case Rotation.South:
                        location.X += TileSize.X;
                        rotation = Rotation.East;
                        break;
                    case Rotation.West:
                        location.Y += TileSize.X;
                        rotation = Rotation.South;
                        break;
                    case Rotation.North:
                        location.X -= TileSize.X;
                        rotation = Rotation.West;
                        break;
                }
            }
            else if (direction == Direction.Right)
            {
                switch (rotation)
                {
                    case Rotation.East:
                        location.Y += TileSize.X;
                        rotation = Rotation.South; // we're now pointing North.
                        break;
                    case Rotation.South:
                        location.X -= TileSize.X;
                        rotation = Rotation.West;
                        break;
                    case Rotation.West:
                        location.Y -= TileSize.X;
                        rotation = Rotation.North;
                        break;
                    case Rotation.North:
                        location.X += TileSize.X;
                        rotation = Rotation.East;
                        break;
                }
            }

            AddNewTileOnAntPosition();
        }
        private void ManageDirection()
        {
            if (GetCurrTile(location) != null)
            {
                switch (GetCurrTile(location).Colors)
                {
                    case TileColor.White:
                        this.direction = Direction.Left;
                        break;
                    case TileColor.Black:
                        this.direction = Direction.Left;
                        break;
                    case TileColor.Red:
                        this.direction = Direction.Right;
                        break;
                    case TileColor.Green:
                        this.direction = Direction.Right;
                        break;
                    //case TileColor.Blue:
                    //    this.direction = Direction.Right;
                    //    break;
                    default:
                        break;
                }
            }
            else
            {
                //if null, treat as white.
                this.direction = Direction.Left;
            }

        }
        private void AddNewTileOnAntPosition()
        {
            //Add tile
            //If current tile has no color, we create a tile that's white.
            if (GetCurrTile(location) != null)
            {
                //Update existing tile color
                switch (GetCurrTile(location).Colors)
                {
                    case TileColor.White:
                        GetCurrTile(location).Colors = TileColor.Black;
                        break;
                    case TileColor.Black:
                        GetCurrTile(location).Colors = TileColor.Red;
                        break;
                    case TileColor.Red:
                        GetCurrTile(location).Colors = TileColor.Green;
                        break;
                    case TileColor.Green:
                        //GetCurrTile(location).Colors = TileColor.Blue;
                        GetCurrTile(location).Colors = TileColor.White;
                        break;
                    //case TileColor.Blue:
                    //    GetCurrTile(location).Colors = TileColor.White;
                    //    break;
                    default:
                        GetCurrTile(location).Colors = TileColor.White;
                        break;
                }
                Point point = new Point(location.X, location.Y);

                //Remove old item. <program thinks its a memory leak>
                RemoveTileAtLocation(location);

                //Replace with new tile 
                map.DrawTile(GetCurrTile(location), point, GetCurrTile(location).Colors);
            }
            else //Update the existing tiles color.
            {
                Tile tile = new Tile(location, TileColor.White);
                Point point = new Point(location.X, location.Y);

                //Add tile to list(memory)
                tileList.Add(tile);

                //Draw new tile
                map.DrawTile(tile, point, tile.Colors);
            }
        }
        public void RemoveTileAtLocation(Point point)
        {
            tileList.Where(tile => tile.Point == point);
        }
        public Tile GetCurrTile(Point point)
        {
            return tileList.Find(tile => tile.Point == point);
        }
    }
}
