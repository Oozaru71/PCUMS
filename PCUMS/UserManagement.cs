using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCUMS
{
    public partial class UserManagement : Form
    {
        int count = File.ReadAllLines(Program.credentialsPath).Length;
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
            String[] Users = new String[count];
            label4.Text = "ID" + "      " + "User" + "       " + "Password" + "       " + "Temp" + "       " + "CPU" + "       " + "RAM" + "       " + "S.Time" + "       " + "S.ID";
            label4.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2.5f, label1.Font.Style);
            label4.Width = 400;
            label4.Height = 20;
            label2.Text = count.ToString() + " Users Found:";
            foreach (string s in File.ReadAllLines(Program.credentialsPath))
            {
                Users[i] = string.Format("{0,0}", s.Split(',')[0]) + "" + string.Format("{0,11}", s.Split(',')[1]) + "" + string.Format("{0,13}", s.Split(',')[2]) + "" + string.Format("{0,19}", s.Split(',')[3]) + "" + string.Format("{0,14}", s.Split(',')[4]) + "" + string.Format("{0,13}", s.Split(',')[5]) + "" + string.Format("{0,12}", s.Split(',')[6])+""+ string.Format("{0,18}", s.Split(',')[7]);              
                if (i < count)
                {
                    i++;
                }
            }


            Label[] labels = new Label[count];
            Button[] buttons = new Button[count];

            //Make Labels
            for (i = 0; i < count; i++)
            {
                labels[i] = new Label();
                labels[i].Visible = true;
                labels[i].Name = "LabelData" + i.ToString();
                labels[i].Text = Users[i].ToString();
                labels[i].Left = 10;
                labels[i].Top = (i + 1) * 40;
                labels[i].Width = 600;
                labels[i].Height = 20;
                labels[i].TextAlign = ContentAlignment.MiddleLeft;
                labels[i].Font = new Font(label1.Font.FontFamily, label1.Font.Size - 2.5f, label1.Font.Style);
            }

            //Make Buttons
            for (i = 0; i < count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Visible = true;
                buttons[i].Name = "ButtonDel" + i.ToString();
                buttons[i].Text = "Delete";
                buttons[i].Left = 620;
                buttons[i].Top = (i + 1) * 40;
                buttons[i].Width = 50;
                buttons[i].Height = 20;
                buttons[i].TextAlign = ContentAlignment.MiddleLeft;
                buttons[i].Click += new EventHandler(btn_Click);
            }

            // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
            for (i = 0; i < count; i++)
            {
                panel1.Controls.Add(labels[i]);
                panel1.Controls.Add(buttons[i]);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            String[] Users = new String[count];
            int i = 0;
            int del = 0;
            bool currentID = false;

            foreach (string s in File.ReadAllLines(Program.credentialsPath))
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


                    using (var sw = new StreamWriter(Program.credentialsPath))
                    {
                        for (int j = 0; i < (count); j++)
                        {
                            if (j == count)
                            {
                                break;
                            }
                            if (i == j)
                            {
                                if (Users[i].Split(',')[0] == Program.AdminID)
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
            count = File.ReadAllLines(Program.credentialsPath).Length;


            if (currentID && (count != 0))
            {
                System.Windows.Forms.MessageBox.Show("Deleting user in current session: " + del + " - Exiting...");
                Program.Requester = 2;
                this.Close();
            }
            else if (count == 0)
            {
                System.IO.File.Delete(Program.credentialsPath);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            Program.Requester = 1;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delall_Click(object sender, EventArgs e)
        {
            string message = "Do you want to delete all users?";
            string title = "Delete All";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                System.IO.File.Delete(Program.credentialsPath);
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
