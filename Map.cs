using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LangtonsAnt
{
    public class Map
    {
        public List<Tile> tileList = new List<Tile>();
        private Graphics graphics;
        public Map (Graphics graphics)
        {
            this.graphics = graphics;
        }
        public void DrawTile(Tile tile, Point point, TileColor tileColor)
        {
            Brush tileBrush;
            switch (tileColor)
            {
                case TileColor.White:
                    tileBrush = Brushes.Wheat;
                    break;
                case TileColor.Black:
                    tileBrush = Brushes.Black;
                    break;
                case TileColor.Red:
                    tileBrush = Brushes.Red;
                    break;
                case TileColor.Green:
                    tileBrush = Brushes.Green;
                    break;
                case TileColor.Blue:
                    tileBrush = Brushes.Blue;
                    break;
                default:
                    tileBrush = Brushes.White;
                    break;
            }

            //Size
            Size size = new Size(TileSize.X, TileSize.Y);

            //Drawing object
            tile.Rectangle = new Rectangle(point, size);
            this.graphics.FillRectangle(tileBrush, tile.Rectangle);
        }
    }
}