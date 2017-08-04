using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uranai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonUranaiStart_Click(object sender, EventArgs e)
        {
            int dateNumber;
            dateNumber = dateTimeUranai.Value.DayOfYear;

            System.Console.WriteLine("dateNumber {0} ", dateNumber);
            System.Console.WriteLine("dateNumber % 5 {0}", dateNumber % 5);

            switch (dateNumber % 5)
            {
                case 0: // 大吉
                    pictureBoxResult.Image = Uranai.Properties.Resources.Daikichi;
                    textResult.Text = "思ったことがコードにかけてものすごいアプリが作れるかも!!";
                    break;
                case 1:
                    pictureBoxResult.Image = Uranai.Properties.Resources.Chuukichi;
                    textResult.Text = "書いたコードがビルドエラーも起きず一発で実行できるかも";
                    break;
                case 2:
                    pictureBoxResult.Image = Uranai.Properties.Resources.Syoukichi;
                    textResult.Text = "できたと思ったらコード書き忘れて動かないところがあるかも";
                    break;
                case 3:
                    pictureBoxResult.Image = Uranai.Properties.Resources.Kichi;
                    textResult.Text = "なかなかエラーが修正できないかも";
                    break;
                case 4:
                    pictureBoxResult.Image = Uranai.Properties.Resources.kyou;
                    textResult.Text = "せっかく書いたプログラムが消えるかも";
                    break;
                default:
                    pictureBoxResult.Image = null;
                    break;

            }
        }
    }
}
