using System;
using PCUMS.Models;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PCUMS
{
    public partial class SystemAdminCheck : Form
    {
        public SystemAdminCheck()
        {
            InitializeComponent();
        }

        //Checking for the current theme and apply to the form
        private void SystemAdminCheck_Load(object sender, EventArgs e)
        {
            if (RulesModel.blackTheme)
            {
                this.BackColor = Color.Black;
                this.button1.BackColor = Color.Black;
                this.button1.ForeColor = Color.White;
                this.button2.BackColor = Color.Black;
                this.button2.ForeColor = Color.White;
                this.newadmin.ForeColor = Color.White;
                this.label3.ForeColor = Color.White;
                this.label5.ForeColor = Color.White;
            }
            else if (!RulesModel.blackTheme)
            {
                this.BackColor = Color.White;
                this.button1.BackColor = Color.White;
                this.button1.ForeColor = Color.Black;
                this.button2.BackColor = Color.White;
                this.button2.ForeColor = Color.Black;
                this.newadmin.ForeColor = Color.Black;
                this.label3.ForeColor = Color.Black;
                this.label5.ForeColor = Color.Black;
            }
        }

        //Go back button -> navigate to login form
        private void button2_Click(object sender, EventArgs e)
        {
            Program.Requester = 2;
            this.Close();
        }

        //Login button which checks if the entered information matches that of the system's administrator
        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            string store = "";

            //Raead from the text file to obtain the system administrator
            StreamReader reader = new StreamReader(PathsModel.credentialsPath);
            while ((result = reader.ReadLine()) != null)
            {
                if (result.Contains(textBox1.Text))
                {
                    store = result;
                }
            }

            //If we obtained data from the text file, set the values for the admin
            if (store != "")
            {
                RulesModel.AdminID = store.Split(',')[0];
                RulesModel.Admin = store.Split(',')[1];
                RulesModel.AdminPass = store.Split(',')[2];

            }
            reader.Close();

            //Check if the entered admin is the system admin
            if (RulesModel.Admin.Equals(textBox1.Text) && RulesModel.AdminPass.Equals(textBox3.Text) && RulesModel.AdminID == "1")
            {
                Program.Requester = 2;
                RulesModel.SystemAdminVerified = true;
                System.Windows.Forms.MessageBox.Show("System Admin Verified. Can now make a new user!");
                this.Close();
            }
            //If user exists but is not system admin, do not allow new admin creation
            else if (RulesModel.Admin.Equals(textBox1.Text) && RulesModel.AdminPass.Equals(textBox3.Text) && RulesModel.AdminID != "1")
            {
                System.Windows.Forms.MessageBox.Show("Must login as System admin with ID 1, Entered ID: " + RulesModel.AdminID);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect admin password or username!");

            }
        }
    }
}
