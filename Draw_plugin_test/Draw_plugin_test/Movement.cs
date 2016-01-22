using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace Draw_plugin_test
{
    public partial class Movement : Form
    {
        Boolean dragging = false;
        Point startx, starty;

        public Movement()
        {
            InitializeComponent();

        }

        private void btnVierkant_Click(object sender, EventArgs e)
        {
            PictureBox image = new PictureBox();
            image.Image = Properties.Resources.vierkantKritiek;
            image.Height = 2000;
            image.Width = 2000;
            image.MouseDown += new MouseEventHandler(setDraggable);
            image.MouseMove += new MouseEventHandler(Draggable);
            image.MouseUp += new MouseEventHandler(removeDraggable);
            shapeContainer.Controls.Add(image);
        }
        private void setDraggable(object sender, MouseEventArgs e)
        {
            dragging = true;
            startx = e.Location;
            
        }

        private void removeDraggable(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        public static Control FindControlAtPoint(Control container, Point pos)
        {
            Control child;
            foreach (Control c in container.Controls)
            {
                if (c.Visible && c.Bounds.Contains(pos))
                {
                    child = FindControlAtPoint(c, new Point(pos.X - c.Left, pos.Y - c.Top));
                    if (child == null) return c;
                    else return child;
                }
            }
            return null;
        }
        public static Control FindControlAtCursor(Form form)
        {
            Point pos = Cursor.Position;
            if (form.Bounds.Contains(pos))
                return FindControlAtPoint(form, form.PointToClient(Cursor.Position));
            return null;
        }
        private void Draggable(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (FindControlAtCursor(this) is PictureBox)
                {
                    PictureBox selected = FindControlAtCursor(this) as PictureBox;
                    selected.Left += (e.X  - startx.X);
                    selected.Top += (e.Y - startx.Y);
                }
            }
        }

        
        private void btnCirkel_Click(object sender, EventArgs e)
        {
        }


    }
}
