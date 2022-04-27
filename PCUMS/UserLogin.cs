using System;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using PCUMS.Models;

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
            newadmin.Enabled = true;
            newadmin.Visible = true;
            clickhere.Enabled = true;
            clickhere.Visible = true;
            forgotpass.Enabled = true;
            forgotpass.Visible = true;
            forgotpassclick.Enabled = true;
            forgotpassclick.Visible = true;
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
            forgotpass.Enabled = false;
            forgotpass.Visible = false;
            forgotpassclick.Enabled = false;
            forgotpassclick.Visible = false;
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
            int count = File.ReadAllLines(PathsModel.credentialsPath).Length;
            bool exists = false;

            String[] SessionIDlist = new String[count];

            foreach (string s in File.ReadAllLines(PathsModel.credentialsPath))
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
                    RulesModel.SessionID = Int32.Parse(textBox1.Text);
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
            StreamReader reader = new StreamReader(PathsModel.credentialsPath);
            while ((result = reader.ReadLine()) != null)
            {
                if (result.Contains(textBox2.Text))
                {
                    store = result;
                }
            }

            //string line = File.ReadLines(RulesModel.credentialsPath).Skip(14).Take(1).First();
            if (store != "")
            {
                RulesModel.AdminID = store.Split(',')[0];
                RulesModel.Admin = store.Split(',')[1];
                RulesModel.AdminPass = store.Split(',')[2];
                RulesModel.Temp = Int32.Parse(store.Split(',')[3]);
                RulesModel.CPU = Int32.Parse(store.Split(',')[4]);
                RulesModel.RAM = Int32.Parse(store.Split(',')[5]);
                RulesModel.SessionT = decimal.Parse(store.Split(',')[6]);
                RulesModel.SessionID = Int32.Parse(store.Split(',')[7]);
                RulesModel.blackTheme = bool.Parse(store.Split(',')[8]);

            }
            reader.Close();
            if (RulesModel.Admin.Equals(textBox2.Text) && RulesModel.AdminPass.Equals(textBox3.Text))
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
            if (RulesModel.blackTheme)
            {
                this.BackColor = Color.Black;
                this.button1.BackColor = Color.Black;
                this.button1.ForeColor = Color.White;
                this.sessionStart.ForeColor = Color.White;
                this.sessionStart.BackColor = Color.Black;
                this.label2.ForeColor = Color.White;
                this.label3.ForeColor = Color.White;
                this.label4.ForeColor = Color.White;
                this.label4.BackColor = Color.Black;
                this.radioButton1.ForeColor = Color.White;
                this.radioButton2.ForeColor = Color.White;
                this.newadmin.ForeColor = Color.White;
                this.label5.ForeColor = Color.White;
                this.username.ForeColor = Color.White;
                this.password.ForeColor = Color.White;
                this.forgotpass.ForeColor = Color.White;
            }
            else if (!RulesModel.blackTheme)
            {
                this.BackColor = Color.White;
                this.button1.BackColor = Color.White;
                this.button1.ForeColor = Color.Black;
                this.sessionStart.ForeColor = Color.Black;
                this.sessionStart.BackColor = Color.White;
                this.label2.ForeColor = Color.Black;
                this.label3.ForeColor = Color.Black;
                this.label4.ForeColor = Color.Black;
                this.label4.BackColor = Color.White;
                this.radioButton1.ForeColor = Color.Black;
                this.radioButton2.ForeColor = Color.Black;
                this.newadmin.ForeColor = Color.Black;
                this.label5.ForeColor = Color.Black;
                this.username.ForeColor = Color.Black;
                this.password.ForeColor = Color.Black;
                this.forgotpass.ForeColor = Color.Black;
            }

            if (File.Exists(PathsModel.credentialsPath))
            {
                if (RulesModel.SystemAdminVerified)
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
            else
            {
                //Welcome
                label2.Visible = false;

                enableRegister();
                adminDisable();
                guestDisable();

                //Go Back
                goback.Enabled = true;
            }    
        }


        private void label1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(PathsModel.credentialsPath))
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
                if (!Directory.Exists(PathsModel.dataPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(PathsModel.dataPath);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                //Checks if the file exists
                if (!File.Exists(PathsModel.credentialsPath))
                {
                    if (usernametext.Text.ToCharArray().Count() > 8 || passwordtext.Text.ToCharArray().Count() > 8)
                    {
                        System.Windows.Forms.MessageBox.Show("Username and password need to contain less than 8 characters");
                    }
                    else
                    {
                        RulesModel.AdminID = "1";
                        PathsModel.csv = RulesModel.AdminID + "," + usernametext.Text + "," + passwordtext.Text + "," + RulesModel.Temp + "," + RulesModel.CPU + "," + RulesModel.RAM + "," + RulesModel.SessionT + "," + RulesModel.SessionID + "," + RulesModel.blackTheme.ToString();
                        System.IO.File.WriteAllText(PathsModel.credentialsPath, PathsModel.csv);
                        RulesModel.AdminID = PathsModel.csv.Split(',')[0];
                        RulesModel.Admin = PathsModel.csv.Split(',')[1];
                        RulesModel.AdminPass = PathsModel.csv.Split(',')[2];
                        RulesModel.Temp = Int32.Parse(PathsModel.csv.Split(',')[3]);
                        RulesModel.CPU = Int32.Parse(PathsModel.csv.Split(',')[4]);
                        RulesModel.RAM = Int32.Parse(PathsModel.csv.Split(',')[5]);
                        RulesModel.SessionT = decimal.Parse(PathsModel.csv.Split(',')[6]);
                        RulesModel.SessionID = Int32.Parse(PathsModel.csv.Split(',')[7]);
                        RulesModel.blackTheme = bool.Parse(PathsModel.csv.Split(',')[8]);
                        System.Windows.Forms.MessageBox.Show("Admin " + RulesModel.Admin + " was created. Please login.");
                        goBack();
                    }
                }
                else
                {
                    string result = "";
                    bool exists = false;
                    StreamReader reader = new StreamReader(PathsModel.credentialsPath);
                    while ((result = reader.ReadLine()) != null)
                    {
                        if (result.Split(',')[1].Equals(usernametext.Text))
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
                        if (usernametext.Text.ToCharArray().Count() > 8 || passwordtext.Text.ToCharArray().Count() > 8)
                        {
                            System.Windows.Forms.MessageBox.Show("Username and password need to contain less than 8 characters");
                        }
                        else
                        {
                            String temp = File.ReadLines(PathsModel.credentialsPath).Last();
                            int tempInt = 0;
                            temp = temp.Split(',')[0];
                            tempInt = Int32.Parse(temp);
                            tempInt = tempInt + 1;
                            temp = tempInt.ToString();
                            RulesModel.AdminID = temp;
                            PathsModel.csv = RulesModel.AdminID + "," + usernametext.Text + "," + passwordtext.Text + "," + RulesModel.Temp + "," + RulesModel.CPU + "," + RulesModel.RAM + "," + RulesModel.SessionT + "," + RulesModel.SessionID + "," + RulesModel.blackTheme.ToString();
                            File.AppendAllText(PathsModel.credentialsPath, PathsModel.csv);
                            RulesModel.AdminID = PathsModel.csv.Split(',')[0];
                            RulesModel.Admin = PathsModel.csv.Split(',')[1];
                            RulesModel.AdminPass = PathsModel.csv.Split(',')[2];
                            RulesModel.Temp = Int32.Parse(PathsModel.csv.Split(',')[3]);
                            RulesModel.CPU = Int32.Parse(PathsModel.csv.Split(',')[4]);
                            RulesModel.RAM = Int32.Parse(PathsModel.csv.Split(',')[5]);
                            RulesModel.SessionT = Int32.Parse(PathsModel.csv.Split(',')[6]);
                            RulesModel.SessionID = Int32.Parse(PathsModel.csv.Split(',')[7]);
                            RulesModel.blackTheme = bool.Parse(PathsModel.csv.Split(',')[8]);
                            System.Windows.Forms.MessageBox.Show("Admin " + RulesModel.Admin + " was created. Please login.");
                            RulesModel.SystemAdminVerified = false;
                            goBack();
                        }
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Create admin credentials and make sure there are no whitespaces!");
            }
        }

        private void forgotpassclick_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Contact the system administrator to reset your password.");
        }
    }
}
