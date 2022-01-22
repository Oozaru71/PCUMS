using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Windows;
using System.IO;
using System.IO.Compression;



namespace PCUMS
{
    public partial class Login1 : Form
    {

        public bool UserCredentialsCreated { get; private set; }
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

        private void save1_Click(object sender, EventArgs e)
        {
                if (String.IsNullOrEmpty(userName.Text) == false && String.IsNullOrEmpty(passWord.Text) == false
                && passWord.Text.Contains(" ") == false && userName.Text.Contains(" ") == false)
                {
                    
                    Program.csv = Program.AdminID + ", " + userName.Text + ", " + passWord.Text;
                    System.IO.File.WriteAllText(Program.credentialsPath, Program.csv);
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

            if (File.Exists(Program.credentialsPath))
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

        private void Login1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Program.credentialsPath))
            {
                string store = System.IO.File.ReadAllText(Program.credentialsPath);
                string admin = store.Split(',')[1];
            
                userName.Enabled = false;
                passWord.Enabled = false;
                save1.Enabled = false;
                
                label2.Text = "Hello " + admin + ", let us get started";
            }
        }



    }
}
