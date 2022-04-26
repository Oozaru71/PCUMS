using System;
using PCUMS.Models;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;



namespace PCUMS
{
    public partial class CredentialsRules : Form
    {

        bool makingNewUser;

        PerformanceCounter ramUsage;
        public CredentialsRules()
        {
            Program.Requester = 0;
            InitializeComponent();


        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            if (File.Exists(PathsModel.credentialsPath))
            {
                var rand = new Random();
                var id = rand.Next(101);
                RulesModel.Temp = numTemp.Value;
                RulesModel.CPU = numCPU.Value;
                RulesModel.RAM = numRAM.Value;
                RulesModel.SessionT = numSess.Value;
                RulesModel.SessionID = id;

                System.Windows.Forms.MessageBox.Show("The Session ID created is:\n" + id + "");
                UpdateAdmin();
                Program.Requester = 3;
                Program.Authority = 2;
                Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Cannot start a session with empty settings!");
        }

        private void Login1_Load(object sender, EventArgs e)
        {
            if (File.Exists(PathsModel.credentialsPath))
            {
                if (RulesModel.blackTheme)
                {
                    dark();
                }
                else if (!RulesModel.blackTheme)
                {
                    light();
                }

                string admin = RulesModel.Admin;
              


                label2.Text = "🙂 Hello " + admin + ", let us get started.";
                button2.Enabled = true;
                makingNewUser = false;
            }
            else
            {
                label2.Text = "🙂 Hello Administrator, let us get started.";
                makingNewUser = true;
            }

            if (RulesModel.AdminID == "1")
            {
                button1.Enabled = true;
                button1.Visible = true;
                label3.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                label3.Visible = false;
            }



            ramUsage = new PerformanceCounter();
            ramUsage.CategoryName = "Memory";
            ramUsage.CounterName = "% Committed Bytes in Use";
            ramUsage.InstanceLifetime = PerformanceCounterInstanceLifetime.Global;

            
            float fram=ramUsage.NextValue();

            numRAM.Minimum = (int)fram+1;
            label14.Text = String.Format("%  This system is currently using {0:0.0} % \n of its RAM.",fram);
     
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Program.Requester = 4;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(PathsModel.credentialsPath))
            {
                if (button2.BackgroundImage.Size.ToString() == PCUMS.Properties.Resources.moon.Size.ToString())
                {
                    button2.BackgroundImage = PCUMS.Properties.Resources.bulb;
                    RulesModel.blackTheme = true;
                    UpdateAdmin();
                    dark();
                }
                else if (button2.BackgroundImage.Size.ToString() == PCUMS.Properties.Resources.bulb.Size.ToString())
                {
                    button2.BackgroundImage = PCUMS.Properties.Resources.moon;
                    RulesModel.blackTheme = false;
                    UpdateAdmin();
                    light();
                }
            }
            else
            {
                Interaction.MsgBox("Please set your credentials and hit save before trying this feature! ");
            }
        }

        public static void UpdateAdmin()
        {
            string store = RulesModel.AdminID + "," + RulesModel.Admin + "," + RulesModel.AdminPass + "," + RulesModel.Temp + "," + RulesModel.CPU + "," + RulesModel.RAM + "," + RulesModel.SessionT + "," + RulesModel.SessionID + "," + RulesModel.blackTheme.ToString();

            string result = "";
            int counter = 0;
            StreamReader reader = new StreamReader(PathsModel.credentialsPath);
            while ((result = reader.ReadLine()) != null)
            {
                counter++;
                if (result.Contains(RulesModel.Admin))
                {
                    break;
                }
            }
            reader.Close();

            lineChanger(store, PathsModel.credentialsPath, counter);
        }

        void dark()
        {
            button2.BackgroundImage = PCUMS.Properties.Resources.bulb;
            this.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            label13.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button3.BackColor = Color.White;
            Continue.ForeColor = Color.White;
            Continue.BackColor = Color.Black;
        }

        void light()
        {
            button2.BackgroundImage = PCUMS.Properties.Resources.moon;
            this.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label12.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.White;
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            Continue.ForeColor = Color.Black;
            Continue.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.Requester = 2;
            this.Close();
        }

       }
}
