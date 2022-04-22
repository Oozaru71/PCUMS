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
using Microsoft.VisualBasic.Devices;
using OpenHardwareMonitor.Hardware;

namespace PCUMS
{


    public partial class Monitoring : MetroFramework.Forms.MetroForm
    {
        bool AlerGiven=false;
        bool AlerGiven2 = false;
        bool AlerGiven3 = false;    

        bool finalGiven = false;
     //   bool finalGiven2 = false;

        int cpuActors = 0;
      //  int cpuActors2 = 0;
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        int counter;
        int counter2;
        int counter3;

        float CPU = (float)Program.CPU;
        float Temp = (float)Program.Temp;
        float RAM=(float)Program.RAM;   

        //   PerformanceCounter c = new PerformanceCounter("Processor Information", "% Idle Time", "_Total",true);
        //   PerformanceCounter k = new PerformanceCounter("Memory", "Available MBytes");
        public Monitoring()
        {
            InitializeComponent();

        }

        private void timer_Tick(object sender, EventArgs e)
        {

            ComputerInfo c1= new ComputerInfo();
            
            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            lblCPU.Text = String.Format("{0:0.00}%", fcpu);
            lblRAM.Text = String.Format("{0:0.00}%", fram);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);

            int currentTemp=getTemp()/cpuActors;
            cpuActors = 0;
            
            //Show temperature value
            ShowTemperature.Text = String.Format(currentTemp.ToString()+" C");
            ShowTemperature.Visible = true;


         

            //float Temp = 90;

            //int messageGiv = 0;
            if (Program.Authority==1) 
            {
                //CPU Rules
                limitCPU(CPU, fcpu);
                //Temp Rules
                limitTemp(Temp,currentTemp);
                //RAM Rules
                limitRAM(RAM, fram);

            }

        }

        private  void limitCPU(float CPU, float fcpu)
        {

            //The cpu is higher than rule cpu- 20 and less than rule cpu -10 
        
                if (fcpu >= (CPU - 10))
                {
                  if (!AlerGiven)
                  {
                      AlerGiven = true;
                      Interaction.MsgBox("Warning! You are getting too close to the cpu limit");
                   }
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
                //The cpu is higher than the rule cpu
               
            
        }
        private void limitTemp(float Temp,float currentTemp)
        {
            if (currentTemp >= (Temp - 10))
            {
                if (!AlerGiven2) 
                {
                    AlerGiven2 = true;
                    Interaction.MsgBox("Warning! You are getting too close to the temperature limit");
                }
               
                //The temp is higher than the rule temp
                if ((currentTemp >= Temp) && AlerGiven2 && !finalGiven)
                {
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
        private void limitRAM(float RAM,float fram)
        {
            if (fram >= (RAM - 5))
            {
                if (!AlerGiven3)
                {
                    AlerGiven3 = true;
                    Interaction.MsgBox("Warning! You are getting too close to the RAM limit");
                }

                //The temp is higher than the rule temp
                if ((fram >= Temp) && AlerGiven3 && !finalGiven)
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
            if (Program.blackTheme)
            {
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
            }
            else if (!Program.blackTheme)
            {
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
                this.label1.ForeColor= Color.Black;
                this.label1.BackColor= Color.White;
                this.label2.ForeColor = Color.Black;
                this.label2.BackColor = Color.White;
                this.label3.ForeColor = Color.Black;
                this.label3.BackColor = Color.White;
                this.label4.ForeColor = Color.Black;
                this.label4.BackColor = Color.White;
            }

            if (Program.Authority == 1)
            {
                if (RAM == pRAM.NextValue())
                {
                    Interaction.MsgBox("The system's conditions have drastically changed and this session cannot be used. \n Contact an admin to change the rules!");
                    this.Close();
                    Program.Requester = 2;
                }
                else {
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
                            Program.blackTheme = bool.Parse(store.Split(',')[8]);
                            Rules.Enabled = false;

                            //Timer for Session Time
                            int SessionTime = (int)Program.SessionT;

                            System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
                            MyTimer.Interval = (SessionTime * 60 * 1000); ; // Timer counts in miliseconds and the user input is given in minutes
                            MyTimer.Tick += new EventHandler(timer1_Tick);
                            MyTimer.Start();
                        }
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
            //
            if (Program.Authority == 1)
            {
                Interaction.MsgBox("Your session time has ended, exiting...");
                System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                Environment.Exit(0);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Your session rules are:\n"
                                               + "----------------------------\n"
                                               + "Temperature: " + Program.Temp + " C" + "\n"
                                               + "CPU: " + Program.CPU + " %" + "\n"
                                               + "RAM: " + Program.RAM + " GB" + "\n"
                                               + "Session Time: " + Program.SessionT + " Minutes");
        }
    }
}
