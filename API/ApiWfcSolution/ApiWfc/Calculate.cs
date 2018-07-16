using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ApiWfc
{
    public class Calculate
    {
        private List<User> ListUsers;
        private List<User> ListUsersSave;

        public Calculate()
        {
            ListUsers = new List<User>();
            InputScore();
        }

        public void AddUser(string name, int points)
        {

            //User TryUser = ListUsers.Find(delegate (User match) { return (match.Name == name); });
            var tryUser = ListUsers.FirstOrDefault(u => u.Name == name);
            if (tryUser is null)
            {
                ListUsers.Add(new User(name, points));
            }
            else
            {
                tryUser.Points += points;
                tryUser.Games++;
            }
            SaveScore();
        }

        public List<User> List()
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
            var i = 0;
            //ListUsersSave = List();
            string[] lines = new string[ListUsers.Count];

            foreach (User listUser in ListUsers)
            {
                lines[i] = listUser.Name + ":" + listUser.Points + ":" + listUser.Games;
                i++;
            }
            File.WriteAllLines(@"C:\Users\julien\Documents\bdd\Score.txt", lines);
        }

        public void InputScore()
        {
            string[] lineSplit;
            Char delimiter = ':';
            int points, games;
            string[] lines = File.ReadAllLines(@"C:\Users\julien\Documents\bdd\Score.txt");
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