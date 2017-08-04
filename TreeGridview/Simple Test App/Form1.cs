using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Simple_Test_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // �ҏW�\�ȏꍇ
            //this.treeGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            var node2 = addNode(null, "name2", "value", "�I����B");
            addNode(node2, "name1-1", "value1", "�I����C");
            addNode(node2, "name1-2", "value1", "�I����C");
            addNode(node2, "name2-1", "value2", "�I����B");
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
                this.treeGridView2.Nodes.Add(node);
            }
            node.Cells[0].Value = name;
            node.Cells[1].Value = val;
            node.Cells[2].Value = sel;
            return node;
        }

        private void treeGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}