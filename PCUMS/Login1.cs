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
        public Login1()
        {
            Program.Requester = 0;
            InitializeComponent();
           
            
        }

        private void save1_Click(object sender, EventArgs e)
        {
           if (String.IsNullOrEmpty(userName.Text) == false && String.IsNullOrEmpty(passWord.Text) == false
                && passWord.Text.Contains(" ") == false && userName.Text.Contains(" ") == false)
           {
               if (!File.Exists(Program.credentialsPath))
               {
                    Program.AdminID = "1";
                    Program.csv = Program.AdminID + "," + userName.Text + "," + passWord.Text;
                    System.IO.File.WriteAllText(Program.credentialsPath, Program.csv);
                    userName.Enabled = false;
                    passWord.Enabled = false;
                    save1.Enabled = false;
               }
               else
               {
                    String temp = File.ReadLines(Program.credentialsPath).Last();
                    int tempInt = 0;
                    temp = temp.Split(',')[0];
                    tempInt = Int32.Parse(temp);
                    tempInt = tempInt + 1;
                    temp = tempInt.ToString();
                    Program.AdminID = temp;
                    Program.csv = Program.AdminID + "," + userName.Text + "," + passWord.Text;
                    File.AppendAllText(Program.credentialsPath, Environment.NewLine + Program.csv);
                    userName.Enabled = false;
                    passWord.Enabled = false;
                    save1.Enabled = false;
               }

                
                    
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
                Program.Requester = 2;
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
            
               // userName.Enabled = false;
              //  passWord.Enabled = false;
              //  save1.Enabled = false;

                
                label2.Text = "Hello " + admin + ", let us get started";
            }
        }



    }
}
