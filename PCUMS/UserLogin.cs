using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCUMS
{
    public partial class UserLogin : Form
    {
        public UserLogin()
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
            string result = "";
            string store = "";
            StreamReader reader = new StreamReader(Program.credentialsPath);
            while ((result = reader.ReadLine()) != null)
            {
                if (result.Contains(textBox2.Text))
                {
                    store = result;
                }
            }
            
            //string line = File.ReadLines(Program.credentialsPath).Skip(14).Take(1).First();
            if (store!="") 
            { 
                Program.AdminID = store.Split(',')[0];
                Program.Admin = store.Split(',')[1];
                Program.AdminPass = store.Split(',')[2];
                Program.Temp = Int32.Parse(store.Split(',')[3]);
                Program.CPU = Int32.Parse(store.Split(',')[4]);
                Program.SessionT = Int32.Parse(store.Split(',')[5]);
                Program.SessionID = Int32.Parse(store.Split(',')[6]);

            }
            reader.Close();
            if (Program.Admin.Equals(textBox2.Text) && Program.AdminPass.Equals(textBox3.Text))
            {
                Program.Requester = 3;
                Program.Authority = 2;
                this.Close();
              
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect admin password or username!");
            }    
        }

        private void sessionStart_Click(object sender, EventArgs e)
        {
            bool exists = false;
            int i = 0;
            int count = File.ReadAllLines(Program.credentialsPath).Length;
            String[] SessionIDlist = new String[count];

            foreach (string s in File.ReadAllLines(Program.credentialsPath))
            {
                SessionIDlist[i] = s.Split(',')[6];
                if (i < count)
                {
                    i++;
                }
            }

            foreach (string s in SessionIDlist)
            {
                if (s.Equals(textBox1.Text))
                {

                    Program.Authority = 1;
                    sessionStart.Enabled = false;
                    exists = true;
                    System.Windows.Forms.MessageBox.Show("SessionID: " + textBox1.Text + " initiated");
                }
            }

            if (!exists)
            {
                System.Windows.Forms.MessageBox.Show("SessionID: " + textBox1.Text + " does not exist");
            }

        }
    }
}
