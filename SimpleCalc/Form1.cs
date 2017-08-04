using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InputCheck(string Text, out int value)
        {

            if (int.TryParse(Text, out value) == true)
                value = int.Parse(Text);
            else
                value = 0;

        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            int valueLeft;
            int valueRight;
            int valueAnswer;

            InputCheck(Input1TextBox.Text, out valueLeft);
            InputCheck(Input2TextBox.Text, out valueRight);
                       
            valueAnswer = valueLeft + valueRight;

            // コメント
            AnswerTextBox.Text = valueAnswer.ToString();
        }
    }
}
