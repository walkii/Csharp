using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApiWfc
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var pointPlayer = "";
            var namePlayer = "";
            var concat = "";
            var client = new ServiceReference1.Service1Client();

            do
            {
                Console.WriteLine("The list");
                input=  Console.ReadLine();
                if (input == "add")
                {
                    Console.WriteLine("the player name");
                    namePlayer = Console.ReadLine();
                    Console.WriteLine("the player point");
                    pointPlayer = Console.ReadLine();
                    concat = namePlayer+":"+ pointPlayer;
                    Console.WriteLine($"{client.SetUser(concat)}");
                }
                else
                {
                    Console.WriteLine($"{client.GetList()}");
                }

            } while (input != "quit");

            client.Close();

        }
    }
}
