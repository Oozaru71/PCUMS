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
  
    
    internal static class Program
    {
        public static string AdminID = "";
        public static string Admin="";
        public static string AdminPass="";
        public static decimal Temp=0 ;
        public static decimal CPU=0 ;
        public static string rootPath;
        public static string dataPath;
        public static string credentialsPath;
        public static string usercountPath;
        public static string csv;
        public static decimal SessionT=0;
        public static int SessionID;
        

        public static int Requester = 0;
        public static int Authority = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            rootPath = Directory.GetCurrentDirectory();
            dataPath = Path.Combine(rootPath, "TextFile");
            credentialsPath = Path.Combine(dataPath, "credentials.txt");
            usercountPath = Path.Combine(dataPath, "userCount.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (File.Exists(Program.credentialsPath))
            {

                Application.Run(new UserLogin());
            }
            else
            {
                Application.Run(new CredentialsRules());
            }
            
            while (true)
            {
                if (Requester == 1)
                {
                    Application.Run(new CredentialsRules());
                }
                else if (Requester == 2)
                {
                    Application.Run(new UserLogin());
                }
                else if (Requester == 3)
                {
                    Application.Run(new Form1());
                }
                else if (Requester == 4)
                {
                    Application.Run(new UserManagement());
                }
                else
                    Environment.Exit(0);
            }
        }
    }
}
