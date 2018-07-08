using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTest01_B
{
    class Program
    {

        static void Main(string[] args)
        {
            FractionList fraction = new FractionList();
            fraction.FareyExtend(4);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            fraction.PrintFractionList();
            Console.ReadLine();
        }
    }
}
