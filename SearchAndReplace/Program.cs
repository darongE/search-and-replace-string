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
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();

           // String text = "atcgcacattatacattattatacat";
           // String pattern = "attataca";

            String text = "banana";
            String pattern = "ana";

            String result = kmp.replacePatternInString(text, pattern, "ol");

            Console.WriteLine("New string => {0}", result);
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
