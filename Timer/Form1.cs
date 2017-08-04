using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class FormTimer : Form
    {
        public FormTimer()
        {
            InitializeComponent();
        }

        private int endTime;
        private int nowTime;
        private int remainingTime;

        private void timerControl_Tick(object sender, EventArgs e)
        {
            nowTime++;
            remainingTime = endTime - nowTime;
            textRemainingTime.Text = remainingTime.ToString();

            if (endTime == nowTime)
            {
                timerControl.Stop();
                MessageBox.Show("Timer Expired.");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // Copy the set time to the remaining time
            //endTime = int.Parse(textSetTime.Text);

            if (int.TryParse(textSetTime.Text, out endTime) != true || endTime <= 0 )
                endTime = 1;

            nowTime = 0;
            remainingTime = endTime - nowTime;
            textRemainingTime.Text = remainingTime.ToString();

            // Start Timer 
            timerControl.Start();
        }
    }
}
