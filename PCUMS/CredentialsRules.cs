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
using PCUMS.Properties;
using System.Diagnostics;
using Microsoft.VisualBasic;


namespace PCUMS
{
    public partial class CredentialsRules : Form
    {

        bool makingNewUser;
        public CredentialsRules()
        {
            Program.Requester = 0;
            InitializeComponent();


        }

        private void save1_Click(object sender, EventArgs e)
        {
            if (makingNewUser)
            {
                if (String.IsNullOrEmpty(userName.Text) == false && String.IsNullOrEmpty(passWord.Text) == false
                     && passWord.Text.Contains(" ") == false && userName.Text.Contains(" ") == false)
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
                        Program.csv = Program.AdminID + "," + userName.Text + "," + passWord.Text + "," + numTemp.Value + "," + numCPU.Value + "," +numRAM.Value+","+ numSess.Value + "," + "0" + "," + Program.blackTheme.ToString();
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
                        userName.Enabled = false;
                        passWord.Enabled = false;
                        save1.Enabled = false;
                        newAd.Enabled = false;
                        numCPU.Enabled = false;
                        numRAM.Enabled = false;
                        numSess.Enabled = false;
                        numTemp.Enabled = false;
                        button1.Enabled = false;
                    }
                    else
                    {
                        string result = "";
                        bool exists = false;
                        StreamReader reader = new StreamReader(Program.credentialsPath);
                        while ((result = reader.ReadLine()) != null)
                        {
                            if (result.Contains(userName.Text))
                            {
                                exists = true;
                            }
                        }

                        reader.Close();

                        if (exists)
                        {
                            System.Windows.Forms.MessageBox.Show("Admin already exists: " + userName.Text);
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
                            Program.csv = Program.AdminID + "," + userName.Text + "," + passWord.Text + "," + numTemp.Value + "," + numCPU.Value + "," + numRAM.Value + "," + numSess.Value + "," + "0" + "," + Program.blackTheme.ToString();
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
                            userName.Enabled = false;
                            passWord.Enabled = false;
                            save1.Enabled = false;
                            newAd.Enabled = false;
                            numCPU.Enabled = false;
                            numSess.Enabled = false;
                            numRAM.Enabled = false;
                            numTemp.Enabled = false;
                            button1.Enabled = false;
                        }
                    }


                    button2.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Create admin credentials and make sure there are no whitespaces!");
                }
            }
            else
            {
                Program.Temp = numTemp.Value;
                Program.CPU = numCPU.Value;
                Program.SessionT = numSess.Value;
                Program.RAM = numRAM.Value;
                UpdateAdmin();
                save1.Enabled = false;
            }
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            //this is a test
            if (File.Exists(Program.credentialsPath))
            {
                var rand = new Random();
                var id = rand.Next(101);
                Program.SessionID = id;

                System.Windows.Forms.MessageBox.Show("The Session ID created is:\n" + id + "");
                UpdateAdmin();
                Program.Requester = 3;
                Program.Authority = 2;
                Close();
            }
            else
                System.Windows.Forms.MessageBox.Show("Create admin credentials!");
        }

        private void Login1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Program.credentialsPath))
            {
                if (Program.blackTheme)
                {
                    dark();
                }
                else if (!Program.blackTheme)
                {
                    light();
                }

                string admin = Program.Admin;

                userName.Enabled = false;
                passWord.Enabled = false;
                button1.Enabled = true;
                newAd.Enabled = true;
              


                label2.Text = "Hello " + admin + ", let us get started";
                button2.Enabled = true;
                makingNewUser = false;
            }
            else
            {
                label2.Text = "Hello Administrator, let us get started.";
                makingNewUser = true;
                

            }
        }

        private void newAd_Click(object sender, EventArgs e)
        {
            userName.Enabled = true;
            passWord.Enabled = true;
            save1.Enabled = true;
            makingNewUser = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Requester = 4;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.credentialsPath))
            {
                if (button2.BackgroundImage.Size.ToString() == PCUMS.Properties.Resources.moon.Size.ToString())
                {
                    button2.BackgroundImage = PCUMS.Properties.Resources.bulb;
                    Program.blackTheme = true;
                    UpdateAdmin();
                    dark();
                }
                else if (button2.BackgroundImage.Size.ToString() == PCUMS.Properties.Resources.bulb.Size.ToString())
                {
                    button2.BackgroundImage = PCUMS.Properties.Resources.moon;
                    Program.blackTheme = false;
                    UpdateAdmin();
                    light();
                }
            }
            else
            {
                Interaction.MsgBox("Please set your credentials and hit save before trying this feature! ");
            }
        }

        void UpdateAdmin()
        {
            string store = Program.AdminID + "," + Program.Admin + "," + Program.AdminPass + "," + Program.Temp + "," + Program.CPU + "," + Program.RAM + "," + Program.SessionT + "," + Program.SessionID + "," + Program.blackTheme.ToString();

            string result = "";
            int counter = 0;
            StreamReader reader = new StreamReader(Program.credentialsPath);
            while ((result = reader.ReadLine()) != null)
            {
                counter++;
                if (result.Contains(Program.Admin))
                {
                    break;
                }
            }
            reader.Close();

            lineChanger(store, Program.credentialsPath, counter);
        }

        void dark()
        {
            button2.BackgroundImage = PCUMS.Properties.Resources.bulb;
            this.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            label13.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Black;
            newAd.ForeColor = Color.White;
            newAd.BackColor = Color.Black;
            button3.ForeColor = Color.White;
            button3.BackColor = Color.Black;
            save1.ForeColor = Color.White;
            save1.BackColor = Color.Black;
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
            label5.ForeColor = Color.Black;
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
            newAd.ForeColor = Color.Black;
            newAd.BackColor = Color.White;
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            save1.ForeColor = Color.Black;
            save1.BackColor = Color.White;
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
