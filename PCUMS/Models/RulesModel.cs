
namespace PCUMS.Models
{
    internal class RulesModel
    {
        //local varibales
        public static string AdminID { get; set; } = "";
        public static string Admin { get; set; } = "";
        public static string AdminPass { get; set; } = "";
        public static decimal Temp { get; set; } = 0;
        public static decimal CPU { get; set; } = 0;
        public static decimal SessionT { get; set; } = 0;
        public static int SessionID { get; set; }
        public static decimal RAM { get; set; } = 0;
        public static bool blackTheme { get; set; } = false;
        //Security Flags
        public static bool SystemAdminVerified { get; set; } = false;
    }
}
