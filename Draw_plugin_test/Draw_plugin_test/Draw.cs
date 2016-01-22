using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw_plugin_test
{
    public partial class Draw : Form
    {
        Bitmap drawArea;
        Graphics figures;
        public Draw()
        {
            InitializeComponent();
            drawArea = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            figures = Graphics.FromImage(drawArea);
        }

        private void btnVierkant_Click(object sender, EventArgs e)
        {
            figures.FillRectangle(Brushes.Red, 0, 0, 100, 100);
            pictureBox2.Image = drawArea;

        }

        private void btnCirkel_Click(object sender, EventArgs e)
        {
            figures.FillEllipse(Brushes.Blue, 0, 0, 100, 100);
            pictureBox2.Image = drawArea;
        }

        private void btnRechthoek_Click(object sender, EventArgs e)
        {
            figures.FillRectangle(Brushes.Blue, 0, 0, 100, 200);
            pictureBox2.Image = drawArea;
        }

        private void btnOvaal_Click(object sender, EventArgs e)
        {
            figures.FillEllipse(Brushes.Blue, 0, 0, 100, 200);
            pictureBox2.Image = drawArea;
        }

        private void btnDriehoek_Click(object sender, EventArgs e)
        {
            PointF point1 = new PointF(25.0F, 125.0F);
            PointF point2 = new PointF(100.0F, 0.0F);
            PointF point3 = new PointF(175.0F, 125.0F);
            PointF[] curvePoints = { point1, point2, point3};
            figures.FillPolygon(Brushes.Green, curvePoints);
            pictureBox2.Image = drawArea;
        }
    }
}
