using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScoreKeeper
{
    class UserInterface
    {
        private enum function { Add, List, Quit };
        private List<User> ListUsers;

        public void Process()
       {
            bool linkBDD = false;
            string readInput = "";

            Console.WriteLine("Type of link, Bdd or none");
            readInput = ControlString(Console.ReadLine());
          
            if (readInput == "Bdd")
            {
                linkBDD = true;
            }

            var calculate = new Calculate(linkBDD);
            //calculate.testbdd();
            if (linkBDD)
            {
                calculate.InputScoreSQL();
            }
            else
            {
                calculate.InputScore();
            }

            InformationUser();

            while (readInput != "Quit")
            {
                readInput =ControlString(Console.ReadLine());

                function func = (function)System.Enum.Parse(typeof(function), readInput);
                switch (func)
                {
                    case function.Add:
                        addFunction(calculate);
                        break;
                    case function.List:
                        listFunction(calculate);
                        break;
                    case function.Quit:
                        quitFunction();
                        break;
                    default:
                        defaultFunction();
                        break;
                }
            }
        }
        
        private void InformationUser()
        {
            Console.WriteLine("Hello to the score keeper.");
            Console.WriteLine("To add a score, write add.");
            Console.WriteLine("To list the scores, write list.");
            Console.WriteLine("To quit the console, write quit.");
        }

        private string ControlString(string inputString)
        {
            inputString = inputString.ToLower().Trim();
            var pattern = "[A-Z0-9/#@.,;:\\!?|$%^*{}]+";
            var replacement = "";

            var rgx = new Regex(pattern);
            var result = rgx.Replace(inputString, replacement);
            if (result.Length != 0)
            {
                result = result.First().ToString().ToUpper() + result.Substring(1);
                return result;
            }
            return "";
        }

        private int ControlInt(string inputString)
        {
            int ReturnPoint;
            var testUser = false;
            inputString = inputString.ToLower();
            var pattern = "[a-zA-Z/\" \"#@.,;:\\!?|$%^*]+";
            var replacement = "";
            var rgx = new Regex(pattern);
            var result = rgx.Replace(inputString, replacement);

            if (int.TryParse(result, out ReturnPoint))
            {
                if (ReturnPoint > 9)
                {
                    Console.WriteLine("the score is greater than 9, press 'y' if your sure.");

                    if (ControlString(Console.ReadLine()) == "Y")
                    {
                        return ReturnPoint;
                    }
                    else { testUser = true; }
                }
                else
                {
                    return ReturnPoint;
                }
            }
            else { testUser = true; }

            if (testUser)
            {
                Console.Clear();
                InformationUser();
                Console.WriteLine("Bad request point");
                return -1;
            }

            return -1;
        }

        private void addFunction(Calculate calculate)
        {
            string readInputIntoWhile = "";
            string nameUser = "";
            int pointsUser = 0;

            Console.WriteLine("Name's player");
            readInputIntoWhile = Console.ReadLine();
            nameUser = ControlString(readInputIntoWhile);

            Console.WriteLine("Enter the " + nameUser + "'s point(s)");
            readInputIntoWhile = Console.ReadLine();
            pointsUser = ControlInt(readInputIntoWhile);

            if (pointsUser != -1)
            {
                calculate.AddUser(nameUser, pointsUser);
                Console.WriteLine("Save ok to " + nameUser + " with " + pointsUser + " point(s)\n");
            }
        }

        private void listFunction(Calculate calculate)
        {
            ListUsers = calculate.List();
            foreach (User list in ListUsers)
            {
                Console.WriteLine("Playeur :" + list.Name + "\t" + " Score :" + list.Points + "\t" + " Game :" + list.Games + "\t" + " Last game :" + list.LastGame);
            }

            if (ListUsers.Count == 0)
            {
                Console.WriteLine("No score available.");
            }

            Console.WriteLine("\n");
        }

        private void quitFunction()
        {
            Console.WriteLine("Thanks, press enter to quit.");
        }

        private void defaultFunction()
        {
            Console.WriteLine("Bad request, try again.");
        }
    }
}