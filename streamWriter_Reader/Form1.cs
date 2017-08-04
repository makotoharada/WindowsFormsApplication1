using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace streamWriter_Reader
{
    public partial class Form1 : Form
    {
        string path = @"C:\Users\Makoto Harada\Documents\Visual Studio 2015\Projects\WindowsFormsApplication1\streamWriter_Reader\TestFile.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_read_Click(object sender, EventArgs e)
        {
            //System.IO.File.OpenRead(path);
            System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Default);
            //while (sr.Peek() >= 0) {
                // TODO: Something wrong. Takes too much time !!
                textBox_read.AppendText(sr.ReadToEnd());
            //}
            sr.Close();
        }

        private void button_write_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, System.Text.Encoding.Default);
            sw.WriteLine("テキストデータ");
            sw.WriteLine("Hello World");
            sw.Close();
        }

        private void button_open_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            //Console.Write(openFileDialog1.FileName + "\n");
        }
    }
}
