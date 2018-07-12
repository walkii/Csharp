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
            var Calculate = new Calculate();
            
            InformationUser();
            string Input = "", InputLower="";
            string InputIntoWhile = "", InputLowerIntoWhile = "";
            string name = "";
            int points = 0;
            List<User> ListUsers;

            while (InputLower != "quit")
            {
                Input = Console.ReadLine();
                InputLower= Input.ToLower();
                if (InputLower == "add")
                {
                    Console.WriteLine("Name's player");
                    InputIntoWhile = Console.ReadLine();
                    name =ControlString(InputIntoWhile);
                    
                    Console.WriteLine("Enter the " + InputLowerIntoWhile + "'s point(s)");
                    InputIntoWhile = Console.ReadLine();
                    points = ControlInt(InputIntoWhile);
                    if (points != -1)
                    {
                        Calculate.add(name, points);
                        Console.WriteLine("Save ok to " + name + " with " + points + " point(s)\n");
                    }
                }
                else if (InputLower == "list") {
                    ListUsers = Calculate.list();
                    foreach (User list in ListUsers)
                    {
                        Console.WriteLine("Playeur :"+ list.Name + " Score :" + list.Points + " Game :" + list.Games);
                    }
                    Console.WriteLine("\n");
                }
                else if (InputLower == "quit")
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

        private string ControlString(string S)
        {
            S = S.ToLower();
            string pattern = "[A-Z0-9/\" \"#@.,;:\\!?|$%^*]+";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(S, replacement);
            return result;
        }

        private int ControlInt(string I)
        {
            int ReturnPoint;
            bool testUser = false;
            I = I.ToLower();
            string pattern = "[a-zA-Z/\" \"#@.,;:\\!?|$%^*]+";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(I, replacement);

            if (int.TryParse(result, out ReturnPoint))
            {
                if (ReturnPoint > 10)
                {
                    Console.WriteLine("the score is greater than 10, press 'y' if your sure.");

                    if (ControlString(Console.ReadLine()) == "y")
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
