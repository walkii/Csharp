using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreKeeper
{
    class Calculate
    {
        private List<User> ListUsers;
        private List<User> ListUsersSave;
        //  private int NbUser = 0;
        public Calculate(){
            //var User = new User();
            ListUsers = new List<User>();
        }

        public void add(string name, int points)
        {
            //User t1 = new User(name,points);
            //ListUsers.Add(t1);
            User TryUser = ListUsers.Find(delegate (User match) { return (match.Name == name); });
            if (TryUser is null)
            {
               // System.Diagnostics.Debug.WriteLine("good: " + TryUser);
                ListUsers.Add(new User(name, points));
            }
            else
            {
               // System.Diagnostics.Debug.WriteLine("TryUser: " + TryUser);
                TryUser.Points +=points;
                TryUser.Games++;
            }
        }

        public List<User> list()
        {
            //trier la liste
            ListUsers.Sort(delegate (User x, User y)
            {
                return y.Points.CompareTo(x.Points);
            });
            return ListUsers;
        }

        public void SaveScore()
        {
            int i = 0;
            ListUsersSave = list();
            string[] lines= new string[ListUsersSave.Count];

            foreach (User listUser in ListUsersSave)
            {
                lines[i]= listUser.Name+":"+ listUser.Points+":"+ listUser.Games;
                i++;
            }
            //= { "First line", "Second line", "Third line" };
            System.IO.File.WriteAllLines(@"C:\Users\julien\Documents\GitHub\Csharp\ScoreKeeperSolution\ScoreKeeper\bdd\Score.txt", lines);
        }

        public void inputScore()
        {
            string[] lineSplit;
            Char delimiter = ':';
            int points, games;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\julien\Documents\GitHub\Csharp\ScoreKeeperSolution\ScoreKeeper\bdd\Score.txt");
            foreach (string line in lines)
            {
                lineSplit = line.Split(delimiter);
                int.TryParse(lineSplit[1], out points);
                int.TryParse(lineSplit[2], out games);
                ListUsers.Add(new User(lineSplit[0], points, games));
            }
        }
    }
}