using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CharTabulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string param0 = args[0];

// Un-comment the following line to use the literal string for tabulation:
//          param0 = "To be or not to be? That is the question. Whether 'tis nobler in the mind to suffer the slings and arrows of outrageous fortune, Or to take arms against a sea of troubles, And by opposing end them. To die: to sleep: Nor more! And by a sleep to say we end the heart-ache and the thousand of natural shocks that flesh is heir to. 'tis a consummation devoutly to be wished";

            var tabulated = Regex.Replace(param0.ToUpper(), "[^a-zA-Z]", "")  // the assignment hints we need to tabulate English letters only; to tabulate all charachers replace this line with param0.ToUpper()
                                  .ToCharArray()
                                  .GroupBy(x => x)
                                  .Select(x => new { value = x.Key, count = x.Count() })
                                  .OrderBy(x => x.value);

            string letters = "";
            string counts = "";

            foreach (var item in tabulated)
            {
                Console.WriteLine(item.value + "  {0,5:N0}", item.count);   // printing in a more user-friendly form

                letters += item.value + " ";    // printing the way
                counts += item.count + " ";     // as spelled out in the assignment
            }

            Console.WriteLine(Environment.NewLine + letters + "   " + counts);   // as per assignment
            Console.ReadKey();
        }
    }
}
