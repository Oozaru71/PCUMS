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
            Program.Requester = 0;
            InitializeComponent();
        }    


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
            textBox1.Enabled = false;
            sessionStart.Enabled = false;
            radioButton2.Checked = false;
           
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            radioButton1.Checked = false;
            
            button1.Enabled = false;
            sessionStart.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string store = System.IO.File.ReadAllText(Program.credentialsPath);
            string admin = store.Split(',')[1];
            string password = store.Split(',')[2];

            if (admin.Equals(textBox2.Text) && password.Equals(textBox3.Text))
            {
                Program.Requester = 1;
                this.Close();
              
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect admin password or username!"+admin+","+password);
            }    
        }
    }
}
