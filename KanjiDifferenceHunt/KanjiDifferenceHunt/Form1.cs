using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanjiDifferenceHunt
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        double current_time;
        string correct_answer = "脛";
        string mistake_answer = "萩";

        private void timer1_Tick(object sender, EventArgs e)
        {
            // How can I add a tick ?
            //current_time = 
            current_time = current_time + 0.02;
            textTimer.Text = current_time.ToString("0.00");
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == correct_answer)
            {
                timer1.Stop();

            }
            else
            {
                current_time = current_time + 3;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            textHunt.Text = correct_answer;


            // 乱数発生
            Random rnd = new System.Random();
            int randomResult = rnd.Next(25);

            for (int i = 0; i < splitContainer1.Panel2.Controls.Count; i++)
            {
                splitContainer1.Panel2.Controls[i].Text = mistake_answer;
            }

            splitContainer1.Panel2.Controls[randomResult].Text = correct_answer;


            current_time = 0;
            timer1.Start();
        }
    }
}
