using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
        
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // label1.Text = "こんにちは3";
            button1.Text = "ボタン2";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            MessageBox.Show("こんにちは");
         
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {

        }

        public abstract class Animal
        {
            public string color;
            public string smell;
            public string taste;

            public abstract string Sing();

        }

        public interface ITopping
        {
            string WrapChocolate();
        }

        public class Cat : Animal, ITopping
        {
            public string ear;

            public override string Sing()
            {
                return "ニャー";
            }

            public string WrapChocolate()
            {
                return "ホワイトチョコ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Cat cat;
        
            cat = new Cat();
            //Animal dog = new Animal();

            cat.color = "白";
            //cat.cry = "にゃー";
            textBox2.Text = cat.Sing();
            //dog.color = "茶";
            //dog.cry = "ワン";
            //textBox3.Text = dog.Sing();
            

        }
    }
}
