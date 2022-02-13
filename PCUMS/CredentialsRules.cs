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
                    if (!File.Exists(Program.credentialsPath))
                    {
                        Program.AdminID = "1";
                        Program.csv = Program.AdminID + "," + userName.Text + "," + passWord.Text + "," + numTemp.Value + "," + numCPU.Value + "," +numRAM.Value+","+ numSess.Value + "," + "0";
                        System.IO.File.WriteAllText(Program.credentialsPath, Program.csv);
                        Program.AdminID = Program.csv.Split(',')[0];
                        Program.Admin = Program.csv.Split(',')[1];
                        Program.AdminPass = Program.csv.Split(',')[2];
                        Program.Temp = Int32.Parse(Program.csv.Split(',')[3]);
                        Program.CPU = Int32.Parse(Program.csv.Split(',')[4]);
                        Program.RAM = Int32.Parse(Program.csv.Split(',')[5]);
                        Program.SessionT = Int32.Parse(Program.csv.Split(',')[6]);
                        Program.SessionID = Int32.Parse(Program.csv.Split(',')[7]);
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
                            Program.csv = Program.AdminID + "," + userName.Text + "," + passWord.Text + "," + numTemp.Value + "," + numCPU.Value + "," + numRAM.Value + "," + numSess.Value + "," + "0";
                            File.AppendAllText(Program.credentialsPath, Program.csv);
                            Program.AdminID = Program.csv.Split(',')[0];
                            Program.Admin = Program.csv.Split(',')[1];
                            Program.AdminPass = Program.csv.Split(',')[2];
                            Program.Temp = Int32.Parse(Program.csv.Split(',')[3]);
                            Program.CPU = Int32.Parse(Program.csv.Split(',')[4]);
                            Program.RAM = Int32.Parse(Program.csv.Split(',')[5]);
                            Program.SessionT = Int32.Parse(Program.csv.Split(',')[6]);
                            Program.SessionID = Int32.Parse(Program.csv.Split(',')[7]);
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
                String store = "";
                store = Program.AdminID + "," + Program.Admin + "," + Program.AdminPass + "," + Program.Temp + "," + Program.CPU + ","+Program.RAM+"," + Program.SessionT + "," + Program.SessionID;

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
                String store = "";

                store = Program.AdminID + "," + Program.Admin + "," + Program.AdminPass + "," + Program.Temp + "," + Program.CPU + ","+Program.RAM+"," + Program.SessionT + "," + Program.SessionID;

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
                string admin = Program.Admin;

                userName.Enabled = false;
                passWord.Enabled = false;
                button1.Enabled = true;
                newAd.Enabled = true;


                label2.Text = "Hello " + admin + ", let us get started";
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
    }
}
