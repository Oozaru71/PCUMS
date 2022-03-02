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

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            //Welcome
            label2.Visible = false;
            guestDisable();
            adminEnable();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            //Welcome
            label2.Visible = false;
            adminDisable();
            guestEnable();
        }

        private void adminEnable()
        {
            label3.Enabled = true;
            label3.Visible = true;
            label5.Enabled = true;
            label5.Visible = true;
            textBox2.Enabled = true;
            textBox2.Visible = true;
            textBox3.Enabled = true;
            textBox3.Visible = true;
            button1.Enabled = true;
            button1.Visible = true;
            newadmin.Enabled = true;
            newadmin.Visible = true;
            clickhere.Enabled = true;
            clickhere.Visible = true;
        }

        private void adminDisable()
        {
            label3.Enabled = false;
            label3.Visible = false;
            label5.Enabled = false;
            label5.Visible = false;
            textBox2.Enabled = false;
            textBox2.Visible = false;
            textBox3.Enabled = false;
            textBox3.Visible = false;
            button1.Enabled = false;
            button1.Visible = false;
            newadmin.Enabled = false;
            newadmin.Visible = false;
            clickhere.Enabled = false;
            clickhere.Visible = false;
        }

        private void guestEnable()
        {
            label4.Enabled = true;
            label4.Visible = true;
            sessionStart.Visible = true;
            sessionStart.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Visible = true;
        }

        private void guestDisable()
        {
            label4.Enabled = false;
            label4.Visible = false;
            sessionStart.Visible = false;
            sessionStart.Enabled = false;
            textBox1.Enabled = false;
            textBox1.Visible = false;
        }

        private void sessionStart_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            int count = File.ReadAllLines(Program.credentialsPath).Length;
            bool exists = false;

            String[] SessionIDlist = new String[count];

            foreach (string s in File.ReadAllLines(Program.credentialsPath))
            {
                SessionIDlist[i] = s.Split(',')[7];
                if (i < count)
                {
                    i++;
                }
            }

            foreach (string s in SessionIDlist)
            {
                if (s.Equals(textBox1.Text) && s != "0")
                {
                    exists = true;
                    Program.Authority = 1;
                    sessionStart.Enabled = false;
                    System.Windows.Forms.MessageBox.Show("SessionID: " + textBox1.Text + " initiated");
                    Program.Requester = 3;
                    Program.SessionID = Int32.Parse(textBox1.Text);
                    this.Close();
                }
            }

            if (!exists)
            {
                System.Windows.Forms.MessageBox.Show("SessionID: " + textBox1.Text + " does not exist");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
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
            if (store != "")
            {
                Program.AdminID = store.Split(',')[0];
                Program.Admin = store.Split(',')[1];
                Program.AdminPass = store.Split(',')[2];
                Program.Temp = Int32.Parse(store.Split(',')[3]);
                Program.CPU = Int32.Parse(store.Split(',')[4]);
                Program.RAM = Int32.Parse(store.Split(',')[5]);
                Program.SessionT = decimal.Parse(store.Split(',')[6]);
                Program.SessionID = Int32.Parse(store.Split(',')[7]);
                Program.blackTheme = bool.Parse(store.Split(',')[8]);

            }
            reader.Close();
            if (Program.Admin.Equals(textBox2.Text) && Program.AdminPass.Equals(textBox3.Text))
            {
                Program.Requester = 1;
                Program.Authority = 2;
                this.Close();

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect admin password or username!");
            }
        }


        private void UserLogin_Load(object sender, EventArgs e)
        {
            if (Program.blackTheme)
            {
                this.BackColor = Color.Black;
                this.button1.BackColor = Color.Black;
                this.button1.ForeColor = Color.White;
                this.sessionStart.ForeColor = Color.White;
                this.sessionStart.BackColor = Color.Black;
                this.label2.ForeColor = Color.White;
                this.label3.ForeColor = Color.White;
                this.label4.ForeColor = Color.White;
                this.radioButton1.ForeColor = Color.White;
                this.radioButton2.ForeColor = Color.White;
                this.newadmin.ForeColor = Color.White;
            }
            else if (!Program.blackTheme)
            {
                this.BackColor = Color.White;
                this.button1.BackColor = Color.White;
                this.button1.ForeColor = Color.Black;
                this.sessionStart.ForeColor = Color.Black;
                this.sessionStart.BackColor = Color.White;
                this.label2.ForeColor = Color.Black;
                this.label3.ForeColor = Color.Black;
                this.label4.ForeColor = Color.Black;
                this.radioButton1.ForeColor = Color.Black;
                this.radioButton2.ForeColor = Color.Black;
                this.newadmin.ForeColor = Color.Black;
            }

            if (Program.SystemAdminVerified)
            {
                //Welcome
                label2.Visible = false;

                enableRegister();
                adminDisable();
                guestDisable();

                //Go Back
                goback.Enabled = true;
                goback.Visible = true;
            }
            else
            {
                //Welcome
                label2.Visible = true;
                adminDisable();
                guestDisable();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Program.credentialsPath))
            {
                //Welcome
                label2.Visible = false;

                enableRegister();
                adminDisable();
                guestDisable();

                //Go Back
                goback.Enabled = true;
                goback.Visible = true;
            }
            else
            {
                Program.Requester = 5;
                this.Close();
            }
        }

        private void enableRegister()
        {
            username.Visible = true;
            usernametext.Visible = true;
            usernametext.Enabled = true;
            password.Visible = true;
            passwordtext.Visible = true;
            passwordtext.Enabled = true;
            register.Visible = true;
            register.Enabled = true;
            radioButton1.Enabled = false;
            radioButton1.Visible = false;
            radioButton2.Enabled = false;
            radioButton2.Visible = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void disableRegister()
        {
            username.Visible = false;
            usernametext.Visible = false;
            usernametext.Enabled = false;
            password.Visible = false;
            passwordtext.Visible = false;
            passwordtext.Enabled = false;
            register.Visible = false;
            register.Enabled = false;
            radioButton1.Enabled = true;
            radioButton1.Visible = true;
            radioButton2.Enabled = true;
            radioButton2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            goBack();
        }

        public void goBack()
        {
            //Welcome
            label2.Visible = true;

            disableRegister();
            adminDisable();
            guestDisable();

            //Go back
            goback.Enabled = false;
            goback.Visible = false;
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernametext.Text) == false && String.IsNullOrEmpty(passwordtext.Text) == false
                 && passwordtext.Text.Contains(" ") == false && usernametext.Text.Contains(" ") == false)
            {
                //Checks if the directory exists
                if (!Directory.Exists(Program.dataPath))
                {
                    Directory.CreateDirectory(Program.dataPath);
                }
                //Checks if the file exists
                if (!File.Exists(Program.credentialsPath))
                {
                    Program.AdminID = "1";
                    Program.csv = Program.AdminID + "," + usernametext.Text + "," + passwordtext.Text + "," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + Program.blackTheme.ToString();
                    System.IO.File.WriteAllText(Program.credentialsPath, Program.csv);
                    Program.AdminID = Program.csv.Split(',')[0];
                    Program.Admin = Program.csv.Split(',')[1];
                    Program.AdminPass = Program.csv.Split(',')[2];
                    Program.Temp = Int32.Parse(Program.csv.Split(',')[3]);
                    Program.CPU = Int32.Parse(Program.csv.Split(',')[4]);
                    Program.RAM = Int32.Parse(Program.csv.Split(',')[5]);
                    Program.SessionT = decimal.Parse(Program.csv.Split(',')[6]);
                    Program.SessionID = Int32.Parse(Program.csv.Split(',')[7]);
                    Program.blackTheme = bool.Parse(Program.csv.Split(',')[8]);
                    System.Windows.Forms.MessageBox.Show("Admin " + Program.Admin + " was created. Please login.");
                    goBack();
                }
                else
                {
                    string result = "";
                    bool exists = false;
                    StreamReader reader = new StreamReader(Program.credentialsPath);
                    while ((result = reader.ReadLine()) != null)
                    {
                        if (result.Contains(usernametext.Text))
                        {
                            exists = true;
                        }
                    }

                    reader.Close();

                    if (exists)
                    {
                        System.Windows.Forms.MessageBox.Show("Admin already exists: " + usernametext.Text);
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
                        Program.csv = Program.AdminID + "," + usernametext.Text + "," + passwordtext.Text + "," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + Program.blackTheme.ToString();
                        File.AppendAllText(Program.credentialsPath, Program.csv);
                        Program.AdminID = Program.csv.Split(',')[0];
                        Program.Admin = Program.csv.Split(',')[1];
                        Program.AdminPass = Program.csv.Split(',')[2];
                        Program.Temp = Int32.Parse(Program.csv.Split(',')[3]);
                        Program.CPU = Int32.Parse(Program.csv.Split(',')[4]);
                        Program.RAM = Int32.Parse(Program.csv.Split(',')[5]);
                        Program.SessionT = Int32.Parse(Program.csv.Split(',')[6]);
                        Program.SessionID = Int32.Parse(Program.csv.Split(',')[7]);
                        Program.blackTheme = bool.Parse(Program.csv.Split(',')[8]);
                        System.Windows.Forms.MessageBox.Show("Admin " + Program.Admin + " was created. Please login.");
                        goBack();
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Create admin credentials and make sure there are no whitespaces!");
            }
        }

    private void button1_Click_1(object sender, EventArgs e)
    {

    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }
    private void button1_Click(object sender, EventArgs e)
    {

    }
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void sessionStart_Click(object sender, EventArgs e)
    {

    }

}
}
