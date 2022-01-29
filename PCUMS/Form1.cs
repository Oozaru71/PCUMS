using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCUMS
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            lblCPU.Text = String.Format("{0:0.00}%", fcpu);
            lblRAM.Text = String.Format("{0:0.00}%", fram);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);


            float CPU = (float)Program.CPU;
            int messageGiv = 0;
            if (Program.Authority==1) {
                if (fcpu > CPU - 20 && CPU-10>fcpu && messageGiv==0)
                {
                    messageGiv++;
                    System.Windows.Forms.MessageBox.Show("Warning! You are approaching the cap of set CPU usage. ");
                }
                else if (fcpu > CPU - 10 && CPU>fcpu && messageGiv==1)
                {
                    messageGiv++;
                    System.Windows.Forms.MessageBox.Show("Warning! You are rapidly approaching the cap of set CPU usage. ");
                }
                else if (fcpu >= CPU&&messageGiv==2)
                {
                    System.Windows.Forms.MessageBox.Show("Warning! You have reached the CPU cap. You will be logged out for breaking the rules! ");
                    System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                    Environment.Exit(0);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Program.Authority == 1)
            {
                string result = "";
                string store = "";
                StreamReader reader = new StreamReader(Program.credentialsPath);
                while ((result = reader.ReadLine()) != null)
                {
                    if (result.Contains(Program.SessionID.ToString()))
                    {
                        store = result;
                    }
                }

                Program.AdminID = "";
                Program.Admin = "";
                Program.AdminPass = "";
                Program.Temp = Int32.Parse(store.Split(',')[3]);
                Program.CPU = Int32.Parse(store.Split(',')[4]);
                Program.SessionT = Int32.Parse(store.Split(',')[5]);
                Program.SessionID = Int32.Parse(store.Split(',')[6]);
                Rules.Enabled = false;

            }

            Program.Requester = 0;
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Requester = 2;
            this.Close();
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            if (Program.Authority == 2)
            {
                Program.Requester = 1;
                this.Close();
            }

                
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Your session rules are:\n" + "----------------------------\n" + "Temperature: " + Program.Temp + " C" + "\n" + "CPU: " + Program.CPU + " %" + "\n" + "Session Time: " + Program.SessionT + " Hours");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
