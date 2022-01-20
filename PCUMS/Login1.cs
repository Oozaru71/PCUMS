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
            Program.rootPath = Directory.GetCurrentDirectory();
            Program.dataPath = Path.Combine(Program.rootPath, "TextFile");
            Program.credentialsPath = Path.Combine(Program.dataPath, "credentials.txt");
            Program.usercountPath = Path.Combine(Program.dataPath, "userCount.txt");

            if (File.Exists(Program.credentialsPath))
            {
                string store = System.IO.File.ReadAllText(Program.credentialsPath);
                string admin = store.Split(',')[0];
                label2.Text = "Hello " + admin + ", let us get started";
            }
            else
            {
                if (String.IsNullOrEmpty(userName.Text) == false && String.IsNullOrEmpty(passWord.Text) == false
                && passWord.Text.Contains(" ") == false && userName.Text.Contains(" ") == false)
                {
                    Program.Admin = userName.Text;
                    Program.AdminPass = passWord.Text;
                    Program.csv = Program.Admin + ", " + Program.AdminPass;
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
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            
            if (Program.Admin != ""||Program.AdminPass!="")
            {
               
                UserCredentialsCreated = true;
                Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Create admin credentials!");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
