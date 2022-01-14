using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCUMS
{
    public partial class Login2 : Form
    {
        public Login2()
        {
            Program.Requester = false;
            InitializeComponent();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==Program.Admin && textBox3.Text==Program.AdminPass)
            {
                Program.Requester = true;
                Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect admin password or username!");
            }    
        }
    }
}
