using System;

namespace ScoreKeeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();

            userInterface.Process();
            Console.ReadLine();
        }
    }
}