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
       public bool UserCredentialsCreated { get; private set;}
        public Login1(bool Value)
        {
            Program.Requester = false;
            InitializeComponent();
            if (Value == true)
            {
                userName.Enabled = false;
                passWord.Enabled = false;
                save1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(userName.Text) == false && String.IsNullOrEmpty(passWord.Text) == false
                &&passWord.Text.Contains(" ")==false && userName.Text.Contains(" ")==false)
            {
                Program.Admin = userName.Text;
                Program.AdminPass = passWord.Text;
                userName.Enabled = false;
                passWord.Enabled = false;
                save1.Enabled = false;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Create admin credentials and make sure there are no whitespaces!");
            }
        }

        private void createS_Click(object sender, EventArgs e)
        {
            Program.CPU=numCPU.Value;

            Program.SessionT=numSess.Value;
            
            Program.Temp=numTemp.Value;

        }


        private void Continue_Click(object sender, EventArgs e)
        {

            if (Program.Admin != "" || Program.AdminPass != "")
            {
                var rand = new Random();
                var id= rand.Next(101);
                Program.SessionID = id;
                System.Windows.Forms.MessageBox.Show("The Session ID created is:\n"+id+"");
                UserCredentialsCreated = true;
                Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Create admin credentials!");
        }
    }
}
