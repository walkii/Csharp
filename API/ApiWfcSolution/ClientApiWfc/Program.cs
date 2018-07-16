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
            var client = new ServiceReference1.Service1Client();

            do
            {
                Console.WriteLine("The list");
                input=  Console.ReadLine();
                if (input == "add")
                {
                    Console.WriteLine($"{client.SetUser("vince:2")}");
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
