using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndReplaceNS
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchAndReplace sar = new SearchAndReplace();

            // String text = "atcgcacattatacattattatacat";
            // String pattern = "attataca";

            String text = "banana";
            String pattern = "banana";

            int result = sar.replacePatternInString(ref text, pattern, "ol");

            Console.WriteLine("New string => {0}", result);
            Console.WriteLine("New string => {0}", text);

            do
            {
       
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
