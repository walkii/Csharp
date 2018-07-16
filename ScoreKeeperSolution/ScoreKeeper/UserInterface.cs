using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScoreKeeper
{
    class UserInterface
    {
       public void Process()
       {
            var calculate = new Calculate();
            //calculate.testbdd();
            //calculate.InputScore();
            calculate.InputScoreSQL();
            InformationUser();
            
            string readInput = "";
            string readInputIntoWhile = "";
            string nameUser = "";
            int pointsUser = 0;
            List<User> ListUsers;

            while (readInput != "quit")
            {
                readInput = Console.ReadLine();
                readInput = readInput.ToLower();
                if (readInput == "add")
                {
                    Console.WriteLine("Name's player");
                    readInputIntoWhile = Console.ReadLine();
                    nameUser =ControlString(readInputIntoWhile);
                    
                    Console.WriteLine("Enter the " + nameUser + "'s point(s)");
                    readInputIntoWhile = Console.ReadLine();
                    pointsUser = ControlInt(readInputIntoWhile);
                    if (pointsUser != -1)
                    {
                        calculate.AddUser(nameUser, pointsUser);
                        Console.WriteLine("Save ok to " + nameUser + " with " + pointsUser + " point(s)\n");
                    }
                }
                else if (readInput == "list") {
                    ListUsers = calculate.List();
                    foreach (User list in ListUsers)
                    {
                        Console.WriteLine("Playeur :" + list.Name + "\t" + " Score :" + list.Points + "\t" + " Game :" + list.Games);
                    }
                    Console.WriteLine("\n");
                }
                else if (readInput == "quit")
                {
                    Console.WriteLine("Thanks, press enter to quit.");
                }
                else
                {
                    Console.WriteLine("Bad request, try again.");
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
            //string pattern = "[A-Z0-9/\" \"#@.,;:\\!?|$%^*{}]+";
            var pattern = "[A-Z0-9/#@.,;:\\!?|$%^*{}]+";
            var replacement = "";
            var rgx = new Regex(pattern);
            var result = rgx.Replace(inputString, replacement);
            result = result.First().ToString().ToUpper() + result.Substring(1);
            return result;
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
    }
}