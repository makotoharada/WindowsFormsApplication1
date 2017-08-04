using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ini_parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Section1
        {
            public string Key1 { get; set; }
            public string Key2 { get; set; }
            public string Key3 { get; set; }
        }

        class NonSection
        {
            public string Key1 { get; set; }
            public string Key2 { get; set; }
            public string Key3 { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // read ini file
             var obj = new Section1();
                obj.ParseFromIni("Section1", @"C:\Users\Makoto Harada\Downloads\sample.ini");
                Console.WriteLine(obj.Key1);
                Console.WriteLine(obj.Key2);
                Console.WriteLine(obj.Key3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
             var obj = new NonSection();
                obj.ParseFromIni("", @"C:\Users\Makoto Harada\Downloads\sample2.ini");
                Console.WriteLine(obj.Key1);
                Console.WriteLine(obj.Key2);
                Console.WriteLine(obj.Key3);

        }
    }
}
