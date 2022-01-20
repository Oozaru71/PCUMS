using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login1 firstLog = new Login1(false);
            //Login2 secondLog = new Login2();
            Application.Run(firstLog);
            while (Requester==false)
            {
                if (firstLog.UserCredentialsCreated)
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
