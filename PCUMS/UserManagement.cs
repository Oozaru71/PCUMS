using System;
using System.Drawing;
using System.Linq;
using System.IO;
using PCUMS.Helpers;
using System.Windows.Forms;
using PCUMS.Models;
using System.Collections.Generic;

namespace PCUMS
{
    public partial class UserManagement : Form
    {
        int count = File.ReadAllLines(PathsModel.credentialsPath).Length;
        StringCleaner cleanMyString = new StringCleaner();
        UserTableModel Table = new UserTableModel(); //Contains all the settings for the rules
        UserTableModel UserInfo = new UserTableModel();
        List<Label> UserIDs = new List<Label>();

        public UserManagement()
        {
            InitializeComponent();
            goBack.Enabled = true;
            Program.Requester = 0;
            initComp();
        }

        void initComp()
        {
            int i = 0;
            
            label4.Text = "ID" + "      " + "User" + "       " + "Password" + "       " + "Temp" + "       " + "CPU" + "       " + "RAM" + "       " + "S.Time" + "       " + "S.ID";
            label4.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2.5f, label1.Font.Style);
            label4.Width = 400;
            label4.Height = 20;
            if (count == 1)
            {
                label2.Text = count.ToString() + " User Found:";
            }
            else
            {
                label2.Text = count.ToString() + " Users Found:";
            }
            foreach (string s in File.ReadAllLines(PathsModel.credentialsPath))
            {
                Table.IDs.Add(s.Split(',')[0]);
                Table.Users.Add(s.Split(',')[1]);
                Table.Passwords.Add(s.Split(',')[2]);
                Table.Temps.Add(s.Split(',')[3]);
                Table.CPUs.Add(s.Split(',')[4]);
                Table.RAMs.Add(s.Split(',')[5]);
                Table.Times.Add(s.Split(',')[6]);
                Table.SIDs.Add(s.Split(',')[7]);
                Table.BlackTheme.Add(s.Split(',')[8]);
            }

            Label[] labelID = new Label[count];
            TextBox[] textboxUsers = new TextBox[count];
            TextBox[] textboxPasswords = new TextBox[count];
            TextBox[] textboxTemps = new TextBox[count];
            TextBox[] textboxCPUs = new TextBox[count];
            TextBox[] textboxRAMs = new TextBox[count];
            TextBox[] textboxTimes = new TextBox[count];
            TextBox[] textboxSIDs = new TextBox[count];

            Button[] buttons = new Button[count];

            //Value to go into text boxes
            string populateMyString = string.Empty;

            //Make textbox
            for (i = 0; i < count; i++)
            {

                //Setup textbox for IDs
                labelID[i] = new Label();
                labelID[i].Visible = true;
                labelID[i].Name = "IdData" + i.ToString();
                populateMyString = cleanMyString.shortenTo8(Table.IDs[i]);
                labelID[i].Text = populateMyString;
                Point location = new Point(0,i*40);
                labelID[i].Location = location;
                labelID[i].TextAlign = ContentAlignment.MiddleLeft;
                labelID[i].Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2.5f, label1.Font.Style);
                labelID[i].ForeColor = Color.Black;
                labelID[i].AutoSize = true;
                UserIDs.Add(labelID[i]);

                //Setup textbox for Users
                location = new Point(55, i * 40);
                textboxUsers[i] = setupTextBoxes(textboxUsers[i], Table.Users[i], location, i, "USERS");

                //Setup textbox for Passwords
                location = new Point(150, i * 40);
                textboxPasswords[i] = setupTextBoxes(textboxPasswords[i], Table.Passwords[i], location, i, "PASSWORDS");

                //Setup textbox for Temps
                location = new Point(250, i * 40);
                textboxTemps[i] = setupTextBoxes(textboxTemps[i], Table.Temps[i], location, i, "TEMPS");

                //Setup textbox for CPU
                location = new Point(330, i * 40);
                textboxCPUs[i] = setupTextBoxes(textboxCPUs[i], Table.CPUs[i], location, i, "CPUS");

                //Setup textbox for RAM
                location = new Point(400, i * 40);
                textboxRAMs[i] = setupTextBoxes(textboxRAMs[i], Table.RAMs[i], location, i, "RAMS");

                //Setup textbox for Times
                location = new Point(490, i * 40);
                textboxTimes[i] = setupTextBoxes(textboxTimes[i], Table.Times[i], location, i, "TIMES");

                //Setup textbox for Session ID
                location = new Point(565, i * 40);
                textboxSIDs[i] = setupTextBoxes(textboxSIDs[i], Table.SIDs[i], location, i, "SIDS");

            }

            //Make Buttons
            for (i = 0; i < count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Visible = true;
                buttons[i].Name = "ButtonDel" + i.ToString();
                buttons[i].Text = "Delete";
                buttons[i].Width = 50;
                buttons[i].Height = 20;
                buttons[i].TextAlign = ContentAlignment.MiddleLeft;
                buttons[i].Click += new EventHandler(btn_Click);
                buttons[i].ForeColor = Color.Black;
                Point location = new Point(630, i * 40);
                buttons[i].Location = location;
            }

            // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
            for (i = 0; i < count; i++)
            {
                panel1.Controls.Add(labelID[i]);
                panel1.Controls.Add(textboxUsers[i]);
                panel1.Controls.Add(textboxPasswords[i]);
                panel1.Controls.Add(textboxTemps[i]); 
                panel1.Controls.Add(textboxCPUs[i]);
                panel1.Controls.Add(textboxRAMs[i]);
                panel1.Controls.Add(textboxTimes[i]);
                panel1.Controls.Add(textboxSIDs[i]);
                panel1.Controls.Add(buttons[i]);
            }
        }

        void TextBox_TextChange(object sender, EventArgs e)
        {
            for (int l = 0; l < count; l++)
            {
                if (((TextBox)(sender)).Name == "USERS" + l.ToString())
                {
                    UserInfo.Users[l] = ((TextBox)(sender)).Text;
                }
                else if (((TextBox)(sender)).Name == "PASSWORDS" + l.ToString())
                {
                    UserInfo.Passwords[l] = ((TextBox)(sender)).Text;
                }
                else if (((TextBox)(sender)).Name == "TEMPS" + l.ToString())
                {
                    UserInfo.Temps[l] = ((TextBox)(sender)).Text;
                }
                else if (((TextBox)(sender)).Name == "CPUS" + l.ToString())
                {
                    UserInfo.CPUs[l] = ((TextBox)(sender)).Text;
                }
                else if (((TextBox)(sender)).Name == "RAMS" + l.ToString())
                {
                    UserInfo.RAMs[l] = ((TextBox)(sender)).Text;
                }
                else if (((TextBox)(sender)).Name == "TIMES" + l.ToString())
                {
                    UserInfo.Times[l] = ((TextBox)(sender)).Text;
                }
                else if (((TextBox)(sender)).Name == "SIDS" + l.ToString())
                {
                    UserInfo.SIDs[l] = ((TextBox)(sender)).Text;
                }
            }
        }

            void btn_Click(object sender, EventArgs e)
        {
            String[] Users = new String[count];
            int i = 0;
            int del = 0;
            bool currentID = false;

            foreach (string s in File.ReadAllLines(PathsModel.credentialsPath))
            {
                Users[i] = s;
                if (i < count)
                {
                    i++;
                }
            }

            for (i = 0; i < count; i++)
            {
                if (((Button)(sender)).Name == "ButtonDel" + i.ToString())
                {


                    using (var sw = new StreamWriter(PathsModel.credentialsPath))
                    {
                        for (int j = 0; i < (count); j++)
                        {
                            if (j == count)
                            {
                                break;
                            }
                            if (i == j)
                            {
                                if (Users[i].Split(',')[0] == RulesModel.AdminID)
                                {
                                    currentID = true;
                                }
                                del = Int32.Parse(Users[i].Split(',')[0]);
                                continue;
                            }
                            else
                            {
                                sw.WriteLine(Users[j]);
                            }
                        }
                    }

                }
            }
            count = File.ReadAllLines(PathsModel.credentialsPath).Length;


            if (currentID && (count != 0))
            {
                System.Windows.Forms.MessageBox.Show("Deleting user in current session: " + del + " - Exiting...");
                Program.Requester = 2;
                this.Close();
            }
            else if (count == 0)
            {
                System.IO.File.Delete(PathsModel.credentialsPath);
                System.Windows.Forms.MessageBox.Show("No users in file: Exiting...");
                Program.Requester = 1;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("UserID: " + (del) + " was deleted");
                Program.Requester = 1;
                this.Close();
            }
        }

        public TextBox setupTextBoxes(TextBox setup, string text, Point location, int index, string Name)
        {
            //Setup textbox for Users
            setup = new TextBox();
            setup.Visible = true;
            setup.Name = Name + index.ToString();
            text = cleanMyString.shortenTo8(text);
            setup.Text = text;
            setup.TextAlign = HorizontalAlignment.Center;
            setup.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2.5f, label1.Font.Style);
            setup.ForeColor = Color.Black;
            setup.Location = location;
            Size size = TextRenderer.MeasureText(setup.Text, setup.Font);
            setup.Width = size.Width;
            setup.Height = size.Height;
            setup.MaxLength = 8;
            setup.TextChanged += new EventHandler(TextBox_TextChange);

            if (Name == "USERS")
            {
                UserInfo.Users.Add(text);
            }
            else if (Name == "PASSWORDS")
            {
                UserInfo.Passwords.Add(text);
            }
            else if (Name == "TEMPS")
            {
                UserInfo.Temps.Add(text);
            }
            else if (Name == "CPUS")
            {
                UserInfo.CPUs.Add(text);
            }
            else if (Name == "RAMS")
            {
                UserInfo.RAMs.Add(text);
            }
            else if (Name == "TIMES")
            {
                UserInfo.Times.Add(text);
            }
            else if (Name == "SIDS")
            {
                UserInfo.SIDs.Add(text);
            }

            return setup;
        }
        private void SaveChanges_Click_1(object sender, EventArgs e)
        {
            File.WriteAllText(PathsModel.credentialsPath, String.Empty);

            for (int i = 0; i < count; i++)
            {
                string writeTo = (UserIDs[i].Text + "," + UserInfo.Users[i] + "," + UserInfo.Passwords[i] + "," + UserInfo.Temps[i] + "," + UserInfo.CPUs[i] + "," + UserInfo.RAMs[i] + "," + UserInfo.Times[i] + "," + UserInfo.SIDs[i] + "," + Table.BlackTheme[i]);
                using (var writer = File.AppendText(PathsModel.credentialsPath))
                {
                    writer.WriteLine(writeTo);
                }
            }
            System.Windows.Forms.MessageBox.Show("User information updated");
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            if (RulesModel.blackTheme == true)
            {
                this.BackColor = Color.Black;
                this.label1.ForeColor = Color.White;
                this.label2.ForeColor = Color.White;
                this.label4.ForeColor = Color.White;
                this.goBack.BackColor = Color.Black;
                this.goBack.ForeColor = Color.White;
                this.delall.BackColor = Color.Black;
                this.delall.ForeColor = Color.White;
                this.SaveChanges.ForeColor = Color.White;
                this.SaveChanges.BackColor = Color.Black;
            }
            else if (RulesModel.blackTheme == false)
            {
                this.BackColor = Color.White;
                this.label1.ForeColor = Color.Black;
                this.label2.ForeColor = Color.Black;
                this.label4.ForeColor = Color.Black;
                this.goBack.BackColor = Color.White;
                this.goBack.ForeColor = Color.Black;
                this.delall.BackColor = Color.White;
                this.delall.ForeColor = Color.Black;
                this.SaveChanges.ForeColor = Color.Black;
                this.SaveChanges.BackColor = Color.White;
            }
        }
        private void goBack_Click_1(object sender, EventArgs e)
        {
            Program.Requester = 1;
            this.Close();
        }

        private void delall_Click_1(object sender, EventArgs e)
        {
            string message = "Do you want to delete all users?";
            string title = "Delete All";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                System.IO.File.Delete(PathsModel.credentialsPath);
                System.Windows.Forms.MessageBox.Show("No users in file: Exiting...");
                Program.Requester = 1;
                this.Close();
            }
            else
            {
                // Do something  
            }
        }
    }
}
