using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Console
{
    abstract class ConsoleView
    {
        protected int SafeInputInt()
        {
            int input;

            string rawInput = System.Console.ReadLine();

            while (!int.TryParse(rawInput, out input))
            {
                System.Console.WriteLine("Podatak nije ispravnog tipa, pokusaj ponovo: ");

                rawInput = System.Console.ReadLine();
            }
            return input;
        }


        protected double SafeInputDouble()
        {
            double input;

            string rawInput = System.Console.ReadLine();

            while (!double.TryParse(rawInput, out input))
            {
                System.Console.WriteLine("Podatak nije ispravnog tipa, pokusaj ponovo: ");

                rawInput = System.Console.ReadLine();
            }
            return input;
        }


        protected DateTime SafeInputDateTime()
        {
            DateTime input;

            string rawInput = System.Console.ReadLine();

            while (!DateTime.TryParse(rawInput, out input))
            {
                System.Console.WriteLine("Podatak nije ispravnog tipa, pokusaj ponovo: ");

                rawInput = System.Console.ReadLine();
            }
            return input;
        }



    }
}
