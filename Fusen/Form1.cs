using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fusen
{
    public partial class FormFusen : Form
    {
        public FormFusen()
        {
            InitializeComponent();
        }

        private void textFusenMemo_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("mouse keydown");

            // if key is escape 
            //      application stop
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private int mouseX;
        private int mouseY;
        //private int Left;
        //private int Right;

        private void textFusenMemo_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("mouse down");

            if (e.Button == MouseButtons.Left)
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;
            }

            // if left button is on, 
            //   x1 = get_x_position();
            //   y1 = get_y_position();
        }

        private void textFusenMemo_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mouseX;
                this.Top += e.Y - mouseY;

                textBox_X.Text = this.Left.ToString();
                textBox_Y.Text = this.Right.ToString();
                textBox_mouse_location.Text = e.Location.ToString();

            }
            // if left button is on
            //   x2 = get_x_position()
            //   y2 = get_y_position()
            //
            //   move window
            //    new_x = x1 + x2;
            //    new_y = y1 + y2;

            //MessageBox.Show("mouse move");
        }

        private void textFusenMemo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("doubleclick");
            // change color
            colorDialogFusen.ShowDialog();
            textFusenMemo.BackColor = colorDialogFusen.Color;
        }
    }
}
