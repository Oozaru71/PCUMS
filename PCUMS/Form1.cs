using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace PCUMS
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        bool AlerGiven=false;
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
            //int messageGiv = 0;
            if (Program.Authority==1) 
            {
                //CPU Rules
                limitCPU(CPU, fcpu);
            }

        }

        private void limitCPU(float CPU, float fcpu)
        {
            //The cpu is higher than rule cpu- 20 and less than rule cpu -10 
            if (fcpu >= (CPU - 10) && !AlerGiven)
            {
                //If this usage is mantained for more than 5 secs
                Interaction.MsgBox("Warning! You are getting too close to the cpu limit");
                AlerGiven = true;

            }
            //The cpu is higher than the rule cpu
            if ((fcpu >= CPU) && AlerGiven)
            {

                Interaction.MsgBox("Warning! You have reached the CPU cap. You will be logged out for having broken the rules! ");
                System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                Environment.Exit(0);
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
                Program.RAM = Int32.Parse(store.Split(',')[5]);
                Program.SessionT = Int32.Parse(store.Split(',')[6]);
                Program.SessionID = Int32.Parse(store.Split(',')[7]);
                Rules.Enabled = false;

                //Timer for Session Time
                int SessionTime = (int)Program.SessionT;
                metroLabel4.Visible = true;
                metroLabel3.Visible = true;

                System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
                MyTimer.Interval = (SessionTime * 60 * 1000); ; // Timer counts in miliseconds and the user input is given in minutes
                MyTimer.Tick += new EventHandler(timer1_Tick);
                MyTimer.Start();
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
            System.Windows.Forms.MessageBox.Show("Your session rules are:\n" 
                                               + "----------------------------\n" 
                                               + "Temperature: " + Program.Temp + " C" + "\n" 
                                               + "CPU: " + Program.CPU + " %" + "\n"
                                               + "RAM: " + Program.RAM + " GB" + "\n"
                                               + "Session Time: " + Program.SessionT + " Hours");
        }

        private void processKiller()
        {
    
                var counterList = new List<PerformanceCounter>();

                while (true)
                {
                    var procDict = new Dictionary<string, float>();

                    Process.GetProcesses().ToList().ForEach(p =>
                    {
                        using (p)
                            if (counterList
                                .FirstOrDefault(c => c.InstanceName == p.ProcessName) == null)
                                counterList.Add(
                                    new PerformanceCounter("Process", "% Processor Time",
                                        p.ProcessName, true));
                    });

                    counterList.ForEach(c =>
                    {
                        try
                        {
                            var percent = c.NextValue() / Environment.ProcessorCount;
                            if (percent < 50)
                                return;
                            //if (c.InstanceName.Trim().ToLower() == "idle")
                            //    return;
                            procDict[c.InstanceName] = percent;
                        }
                        catch (InvalidOperationException) { /* some will fail */ }
                    });


                procDict.OrderByDescending(d => d.Value).ToList();
                        

                    
                }
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.Authority == 1)
            {
                Interaction.MsgBox("Your session time has ended, exiting...");
                System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                Environment.Exit(0);
            }
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {
        }
    }
}
