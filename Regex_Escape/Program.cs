using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regex_Escape
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Minions - Official Trailer(HD) - Illumination.mp4";
            Console.WriteLine(test);

            string output;
            output = Regex.Escape(test);
            Console.WriteLine(output);

        }
    }
}
