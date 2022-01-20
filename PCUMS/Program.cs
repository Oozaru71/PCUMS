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
        public static string rootPath;
        public static string dataPath;
        public static string credentialsPath;
        public static string usercountPath;
        public static string Admin="";
        public static string AdminPass="";
        public static string AdminID = "";
        public static string csv;
        public static string CPU = "";
        public static string TEMP = "";
        public static string TIME = "";
        public static bool Requester = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            rootPath = Directory.GetCurrentDirectory();
            dataPath = Path.Combine(Program.rootPath, "TextFile");
            credentialsPath = Path.Combine(Program.dataPath, "credentials.txt");
            usercountPath = Path.Combine(Program.dataPath, "userCount.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login1 firstLog = new Login1(false);
            //Login2 secondLog = new Login2();
            Application.Run(firstLog);
            while (Requester==false)
            {
                if (firstLog.UserCredentialsCreated || File.Exists(credentialsPath))
                {

                    Application.Run(new Login2());
                }
                if (Requester)
                {
                    Application.Run(new Login1(true));
                }
                else
                    Environment.Exit(0);
            }
        }
    }
}
