using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCUMS.Helpers
{
    public class StringCleaner
    {
        public string shortenTo8(string input)
        {
            if (input.ToString().ToCharArray().Count() > 8)
            {
                var shortenString = input.ToString().ToCharArray();
                input = string.Empty;
                foreach (var character in shortenString)
                {
                    if (input.ToString().ToCharArray().Count() == 8)
                    {
                        break;
                    }
                    input += character.ToString();
                }
            }
            return input.ToLower();
        }
    }
}
