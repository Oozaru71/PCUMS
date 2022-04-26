using System;
using System.Windows.Forms;
using System.IO;
using PCUMS.Models;

namespace PCUMS
{
  
    
    internal static class Program
    {   

        public static int Requester = 0;
        public static int Authority = 0;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (File.Exists(PathsModel.credentialsPath))
            {

                Application.Run(new UserLogin());
            }
            else
            {
                Application.Run(new UserLogin());
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
                    Application.Run(new Monitoring());
                }
                else if (Requester == 4)
                {
                    Application.Run(new UserManagement());
                }
                else if (Requester == 5)
                {
                    Application.Run(new SystemAdminCheck());
                }
                else
                    Environment.Exit(0);
            }
        }
    }
}
