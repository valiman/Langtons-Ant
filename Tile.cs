using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LangtonsAnt
{
    public class Tile
    {
        private TileColor colors;
        private Point point;
        private Rectangle rectangle;

        public Tile(Point p, TileColor colors)
        {
            this.point = p;
            this.colors = colors;
        }
        public TileColor Colors { 
            get { return this.colors; } 
            set { this.colors = value; } 
        }
        public Point Point { 
            get { return this.point; } 
            set { this.point = value; } 
        }
        public Rectangle Rectangle { 
            get { return this.rectangle; } 
            set { this.rectangle = value; } 
        }
    }
}
