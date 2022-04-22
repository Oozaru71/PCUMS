using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCUMS.Models
{
    public class UserTableModel
    {
        public List<string> IDs { get; set; } = new List<string>(); //Contains the Usernames
        public List<string> Users { get; set; } = new List<string>();//Contains the IDs
        public List<string> Passwords { get; set; } = new List<string>(); //Contains the Passwords
        public List<string> Temps { get; set; } = new List<string>(); //Contains the Temperature Rules
        public List<string> CPUs { get; set; } = new List<string>(); //Contains the CPU rules
        public List<string> RAMs { get; set; } = new List<string>(); //Contains the RAM rules
        public List<string> Times { get; set; } = new List<string>(); //Contains the Session Time rules
        public List<string> SIDs { get; set; } = new List<string>(); //Contains the Session IDs
        public List<string> BlackTheme { get; set; } = new List<string>(); //Contains whether the user had black theme selected
    }
}
