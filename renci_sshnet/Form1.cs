using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace renci_sshnet
{
    public partial class Form1 : Form
    {

        Public sshClient As Renci.SshNet.SshClient
        Private sshConnectionInfo As Renci.SshNet.PasswordConnectionInfo


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
