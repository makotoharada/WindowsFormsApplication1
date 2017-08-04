using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    public partial class Form1 : Form
    {

        //test objTest;

        //public Form1()
        //{
        //    InitializeComponent();


        //    PropertyGrid propertyGrid1 = new PropertyGrid();
        //    propertyGrid1.Name = "propertyGrid1";
        //    propertyGrid1.Dock = DockStyle.Fill;
        //    Controls.Add(propertyGrid1);

        //    objTest = new test() { a = 12, b = 34, s2 = "TEST" };
        //    propertyGrid1.SelectedObject = objTest;


        //}

        public Form1()
        {
            InitializeComponent();

            // 編集可能な場合
            //this.treeGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            var node2 = addNode(null, "name2", "value", "選択肢B");
            addNode(node2, "name1-1", "value1", "選択肢C");
            addNode(node2, "name1-2", "value1", "選択肢C");
            addNode(node2, "name2-1", "value2", "選択肢B");
        }

        private AdvancedDataGridView.TreeGridNode addNode(AdvancedDataGridView.TreeGridNode parent, string name, string val, string sel) 
        {
            AdvancedDataGridView.TreeGridNode node = new AdvancedDataGridView.TreeGridNode();
            node.CreateCells(this.treeGridView1);
            if (parent != null)
            {
                parent.Nodes.Add(node);
            }
            else
            {
                this.treeGridView1.Nodes.Add(node);
            }
            node.Cells[0].Value = name;
            node.Cells[1].Value = val;
            node.Cells[2].Value = sel;
            return node;
        }

    }


    class test
    {
        public int a;

        public int mya
        {
            get { return a; }
            set { a = value; }
        }

        public int b;
        public int c;
        public int d;
        public int e;
        public string s1;
        public string s2;
    }

}
