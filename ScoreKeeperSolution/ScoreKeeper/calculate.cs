using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace ScoreKeeper
{
    class Calculate
    {
        private List<User> ListUsers;
        private List<User> ListUsersSave;
        private bool linkBdd;

        public Calculate(bool linkBDD)
        {
            ListUsers = new List<User>();
            linkBdd = linkBDD;
        }

        public void AddUser(string name, int points)
        {
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

            if (linkBdd)
            {
                SaveScoreSQL(ListUsers.FirstOrDefault(u => u.Name == name));
            }
            else
            {
                SaveScore();
            }
        }

        public List<User> List()
        {
            ListUsers.Sort(delegate (User x, User y)
            {
                return y.Points.CompareTo(x.Points);
            });
            return ListUsers;
        }

        public void SaveScore()
        {
            var i = 0;
            ListUsersSave = List();
            string[] lines = new string[ListUsersSave.Count];

            foreach (User listUser in ListUsersSave)
            {
                lines[i] = listUser.Name + ":" + listUser.Points + ":" + listUser.Games + ":" + listUser.LastGame;
                i++;
            }
            File.WriteAllLines(@".\bdd\Score.txt", lines);
        }

        public void InputScore()
        {
            string[] lineSplit;
            Char delimiter = ':';
            int points, games;
            DateTime lastGame;
            string[] lines = File.ReadAllLines(@".\bdd\Score.txt");

            foreach (string line in lines)
            {
                lineSplit = line.Split(delimiter);
                int.TryParse(lineSplit[1], out points);
                int.TryParse(lineSplit[2], out games);
                DateTime.TryParse(lineSplit[3], out lastGame);
                ListUsers.Add(new User(lineSplit[0], points, games, lastGame));
            }
        }

        public void SaveScoreSQL(User user)
        {
            SqlParameter myParamName, myParamPoints, myParamGames, myParamLastGame;

            using (var db = new ScoreKeeperContext())
            {
                myParamName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                myParamName.Value = user.Name;
                myParamPoints = new SqlParameter("@Points", SqlDbType.Int, 4);
                myParamPoints.Value = user.Points;
                myParamGames = new SqlParameter("@Games", SqlDbType.Int, 4);
                myParamGames.Value = user.Games;
                myParamLastGame = new SqlParameter("@LastGame", SqlDbType.DateTime, 255);
                myParamLastGame.Value = user.LastGame;

                db.Database.ExecuteSqlCommand("exec InserUser @Name, @Points, @Games, @LastGame", myParamName, myParamPoints, myParamGames, myParamLastGame);
            }

        }

        public void InputScoreSQL()
        {
            using (var db = new ScoreKeeperContext())
            {
                var query = from b in db.scores select b;
                foreach (var item in query)
                {
                    ListUsers.Add(new User(item.NAME, item.POINTS, item.GAMES, item.LASTGAME));
                }
            }
        }

        public void testbdd()
        {
            using (var db = new ScoreKeeperContext())
            {
                //var score = new score { NAME = "test", POINTS = 2, GAMES = 1, LASTGAME = DateTime.Now };
                // db.scores.Add(score);
                //db.SaveChanges();

                var myParamName = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                myParamName.Value = "tes";
                var myParamPoints = new SqlParameter("@Points", SqlDbType.Int, 4);
                myParamPoints.Value = 1;
                var myParamGames = new SqlParameter("@Games", SqlDbType.Int, 4);
                myParamGames.Value = 1;
                var myParamLastGame = new SqlParameter("@LastGame", SqlDbType.DateTime, 255);
                myParamLastGame.Value = DateTime.Now;

                var courseList = db.Database.ExecuteSqlCommand("exec InserUser @Name, @Points, @Games, @LastGame", myParamName, myParamPoints, myParamGames, myParamLastGame);

                var query = from b in db.scores select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.NAME);
                }
            }
        }
    }
}