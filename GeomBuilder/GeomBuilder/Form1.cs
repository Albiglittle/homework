using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometryLibrary;

namespace GeomBuilder
{
    public partial class Form1 : Form
    {
        private Geometry.Point[] points = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Satisfy_Click(object sender, EventArgs e)
        {
            var rnd = new System.Random();
            Func<int> next = () => rnd.Next(0, 400);
            Func<Geometry.Point> nextPt = () => new Geometry.Point(next(), next());

            points = (from _ in Enumerable.Range(0, 4) select nextPt()).ToArray();
            var res = Geometry.Checker(points[0], points[1], points[2], points[3]);

            label1.BackColor = res ? Color.Green : Color.Red;
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (points != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Func<Geometry.Point, Point> convert = (p) => new Point((int)p.X, (int)p.Y);

                e.Graphics.DrawLine(new Pen(Color.Blue), convert(points[0]), convert(points[1]));
                e.Graphics.DrawLine(new Pen(Color.Maroon), convert(points[2]), convert(points[3]));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
