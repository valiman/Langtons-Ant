using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LangtonsAnt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Graphics g;
        private Map map;
        private Ant ant;
        private Label lbl;

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl = label1;
            Point antStartPoint = new Point(600, 600);

            g = this.CreateGraphics();
            map = new Map(g);
            ant = new Ant(map, map.tileList, antStartPoint); //Ant need to be aware of the tile list object.
        }
        public TileColor ChangeTileColor(TileColor currColor)
        {
            switch (currColor)
            {
                case TileColor.White:
                    return TileColor.Black;
                case TileColor.Black:
                    return TileColor.Red;
                case TileColor.Red:
                    return TileColor.Green;
                case TileColor.Green:
                //    return TileColor.Blue;
                    return TileColor.White;
                //case TileColor.Blue:
                //    return TileColor.White;
                default:
                    return TileColor.White;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread antThread = new Thread(new ThreadStart(tAnt));
            antThread.Start();
        }
        public void tAnt()
        {
            Label lblCount = new Label();
            for (int i = 0; i < 1000000; i++)
            {
                ant.MoveDirection();
                lbl.Invoke((MethodInvoker)(() => lbl.Text = i.ToString()));
            }
        }
    }
}
