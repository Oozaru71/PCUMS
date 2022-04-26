using System.IO;

namespace PCUMS.Models
{
    internal class PathsModel
    {
        //text locations
        public static string rootPath { get; set; } = Directory.GetCurrentDirectory();
        public static string dataPath { get; set; } = Path.Combine(rootPath, "TextFile");
        public static string credentialsPath { get; set; } = Path.Combine(dataPath, "credentials.txt");
        public static string usercountPath { get; set; } = Path.Combine(dataPath, "userCount.txt");
        public static string csv { get; set; }
        //image locations
        public static string images { get; set; } = Path.Combine(rootPath, "images");
    }
}
