using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreKeeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var Interface = new UserInterface();
            Interface.Process();
            Console.ReadLine();
        }
    }
}