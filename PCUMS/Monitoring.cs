using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using OpenHardwareMonitor.Hardware;
using PCUMS.Models;

namespace PCUMS
{


    public partial class Monitoring : MetroFramework.Forms.MetroForm
    {
        //Booleans to show alerts
        bool AlerGiven = false;
        bool AlerGiven2 = false;
        bool AlerGiven3 = false;

        //Boolean to show the final alert
        bool finalGiven = false;

        //The number of cores
        int cpuActors = 0;

        //To check how long a rule has been broken for
        int counter;
        int counter2;
        int counter3;



        //keeps a local timer for label
        int totalSecs = (int)RulesModel.SessionT * 60;

        public Monitoring()
        {
            InitializeComponent();

        }

        private void timer_Tick(object sender, EventArgs e)
        {


            ComputerInfo c1 = new ComputerInfo();

            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            lblCPU.Text = String.Format("{0:0.00}%", fcpu);
            lblRAM.Text = String.Format("{0:0.00}%", fram);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);

            int currentTemp = getTemp() / cpuActors;
            cpuActors = 0;


            ShowTemperature.Text = String.Format(currentTemp.ToString() + " C");
            ShowTemperature.Visible = true;


            if (Program.Authority == 1)
            {
                //CPU Rules
                limitCPU((float)RulesModel.CPU, fcpu);
                //Temp Rules
                limitTemp((float)RulesModel.Temp, currentTemp);
                //RAM Rules
                limitRAM((float)RulesModel.RAM, fram);

                totalSecs--;
                int hr = (totalSecs / 3600);
                int minutes = (totalSecs - (hr * 3600)) / 60;
                int seconds = totalSecs - ((minutes * 60) + (hr * 3600));

                countdown.Text = hr.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
                countdown.Refresh();


            }
   

        }

        private void limitCPU(float CPU, float fcpu)
        {
            //gives first aler based on CPU        
            if (fcpu >= (CPU - 10))
            {
                if (!AlerGiven)
                {
                    AlerGiven = true;
                    Interaction.MsgBox("Warning! You are getting too close to the cpu limit");
                }
                //gives final alert based on CPU
                if ((fcpu >= CPU) && AlerGiven && !finalGiven)
                {
                    if (counter >= 4)
                    {
                        finalGiven = true;
                        Interaction.MsgBox("Warning! You have reached the CPU cap. You will be logged out for having broken the rules! ");
                        System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                        Environment.Exit(0);
                    }
                    else
                    {
                        counter++;
                    }
                }


            }



        }
        private void limitTemp(float Temp, float currentTemp)
        {
            //this section handles the alerts
            if (currentTemp >= (Temp - 10))
            {
                //gives first warning based on temperature
                if (!AlerGiven2)
                {
                    AlerGiven2 = true;
                    Interaction.MsgBox("Warning! You are getting too close to the temperature limit");
                }


                if ((currentTemp >= Temp) && AlerGiven2 && !finalGiven)
                {
                    //gives final warning based on temperature
                    if (counter2 >= 4)
                    {
                        finalGiven = true;
                        Interaction.MsgBox("Warning! You have reached the temperature cap. You will be logged out for having broken the rules! ");
                        System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                        Environment.Exit(0);
                    }
                    else
                    {
                        counter2++;
                    }
                }


            }

        }
        private void limitRAM(float RAM, float fram)
        {
            //gives first alert based on ram
            if (fram >= (RAM - 5))
            {
                if (!AlerGiven3)
                {
                    AlerGiven3 = true;
                    Interaction.MsgBox("Warning! You are getting too close to the RAM limit");
                }

                //gives final alert based on ram
                if ((fram >= (float)RulesModel.RAM) && AlerGiven3 && !finalGiven)
                {
                    if (counter3 >= 4)
                    {
                        finalGiven = true;
                        Interaction.MsgBox("Warning! You have reached the RAM cap. You will be logged out for having broken the rules! ");
                        System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                        Environment.Exit(0);
                    }
                    else
                    {
                        counter3++;
                    }
                }


            }

        }
        private int getTemp()
        {
            //finds temp using OpenHardwareMonitor, looks at all cores temp

            int cputemp = 0;
            UpdateVisitor updateVisitor = new UpdateVisitor();
            OpenHardwareMonitor.Hardware.Computer computer = new OpenHardwareMonitor.Hardware.Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.Accept(updateVisitor);
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            cputemp += (int)computer.Hardware[i].Sensors[j].Value;
                            cpuActors++;
                        }
                    }
                }
            }
            computer.Close();
            return cputemp;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (RulesModel.blackTheme)
            {
                //handles blackTheme
                this.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.BackColor = Color.Black;
                this.button2.BackColor = Color.White;
                this.metroLabel1.ForeColor = Color.White;
                this.metroLabel2.ForeColor = Color.White;
                this.lblCPU.ForeColor = Color.White;
                this.lblRAM.ForeColor = Color.White;
                this.button1.ForeColor = Color.Black;
                this.button1.BackColor = Color.White;
                this.Rules.BackColor = Color.White;
                this.Rules.ForeColor = Color.Black;
                this.ShowTemperature.ForeColor = Color.White;
                this.ShowTemperature.BackColor = Color.Black;
                this.label1.ForeColor = Color.White;
                this.label1.BackColor = Color.Black;
                this.label2.ForeColor = Color.White;
                this.label2.BackColor = Color.Black;
                this.label3.ForeColor = Color.White;
                this.label3.BackColor = Color.Black;
                this.label4.ForeColor = Color.White;
                this.label4.BackColor = Color.Black;

                this.countdown.ForeColor = Color.White;
                this.countdown.BackColor = Color.Black;

                this.cLabel.ForeColor = Color.White;
                this.cLabel.BackColor = Color.Black;

            }
            else if (!RulesModel.blackTheme)
            {
                //handles back lightTheme
                this.Theme = MetroFramework.MetroThemeStyle.Light;
                this.BackColor = Color.White;
                this.button2.BackColor = Color.White;
                this.metroLabel1.ForeColor = Color.Black;
                this.metroLabel2.ForeColor = Color.Black;
                this.lblCPU.ForeColor = Color.Black;
                this.lblRAM.ForeColor = Color.Black;
                this.button1.ForeColor = Color.Black;
                this.button1.BackColor = Color.White;
                this.Rules.BackColor = Color.White;
                this.Rules.ForeColor = Color.Black;
                this.ShowTemperature.ForeColor = Color.Black;
                this.ShowTemperature.BackColor = Color.White;
                this.label1.ForeColor = Color.Black;
                this.label1.BackColor = Color.White;
                this.label2.ForeColor = Color.Black;
                this.label2.BackColor = Color.White;
                this.label3.ForeColor = Color.Black;
                this.label3.BackColor = Color.White;
                this.label4.ForeColor = Color.Black;
                this.label4.BackColor = Color.White;

                this.countdown.ForeColor = Color.Black;
                this.countdown.BackColor = Color.White;

                this.cLabel.ForeColor = Color.Black;
                this.cLabel.BackColor = Color.White;
            }

            if (Program.Authority == 1)
            {



                string result = "";
                string store = "";
                StreamReader reader = new StreamReader(PathsModel.credentialsPath);
                while ((result = reader.ReadLine()) != null)
                {
                    if (result.Contains(RulesModel.SessionID.ToString()))
                    {
                        store = result;
                    }
                }

                RulesModel.AdminID = "";
                RulesModel.Admin = "";
                RulesModel.AdminPass = "";
                RulesModel.Temp = Int32.Parse(store.Split(',')[3]);
                RulesModel.CPU = Int32.Parse(store.Split(',')[4]);
                RulesModel.RAM = Int32.Parse(store.Split(',')[5]);
                RulesModel.SessionT = Int32.Parse(store.Split(',')[6]);
                RulesModel.SessionID = Int32.Parse(store.Split(',')[7]);
                RulesModel.blackTheme = bool.Parse(store.Split(',')[8]);
                


                int SessionTime = (int)RulesModel.SessionT;

                System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
                MyTimer.Interval = (SessionTime * 60 * 1000); ; // Timer counts in miliseconds and the user input is given in minutes
                MyTimer.Tick += new EventHandler(timer1_Tick);
                MyTimer.Start();
                if ((float)RulesModel.RAM == pRAM.NextValue())
                {
                    Interaction.MsgBox("The system's conditions have drastically changed and this session cannot be used. \n Contact an admin to change the rules!");
                    this.Close();
                    Program.Requester = 2;
                }

                button2.Visible = false;
                label2.Visible = false;


                button1.Visible = false;
                label4.Visible = false;
            }

            Program.Requester = 0;
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //handles form switching
            Program.Requester = 2;
            RulesModel.SystemAdminVerified = false;
            this.Close();
        }

        private void Rules_Click(object sender, EventArgs e)
        {
            //shows rules of session
            System.Windows.Forms.MessageBox.Show("Your session rules are:\n"
                                               + "----------------------------\n"
                                               + "Temperature: " + RulesModel.Temp + " C" + "\n"
                                               + "CPU: " + RulesModel.CPU + " %" + "\n"
                                               + "RAM: " + RulesModel.RAM + " GB" + "\n"
                                               + "Session Time: " + RulesModel.SessionT + " Minutes");

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //handles exiting based on timer

            if (Program.Authority == 1)
            {


                Interaction.MsgBox("Your session time has ended, exiting...");
                System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                Environment.Exit(0);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //form switching
            if (Program.Authority == 2)
            {
                Program.Requester = 1;
                this.Close();
            }
        }
    }
}
