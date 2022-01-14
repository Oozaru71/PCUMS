using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace PCUMS
{
    public partial class Login1 : Form
    {
       
        public Login1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Admin =userName.Text;
            Program.AdminPass = passWord.Text;
            userName.Enabled = false;
            passWord.Enabled = false;

    
        }
    }
}
