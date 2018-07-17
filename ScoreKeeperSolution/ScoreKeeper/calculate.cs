using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ScoreKeeper
{
    class Calculate
    {
        private List<User> ListUsers;
        private List<User> ListUsersSave;

        public Calculate(){
            ListUsers = new List<User>();
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
                tryUser.Points +=points;
                tryUser.Games++;
            }
            //SaveScore();
            SaveScoreSQL(ListUsers.FirstOrDefault(u => u.Name == name));
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
            ListUsersSave = List();
            string[] lines= new string[ListUsersSave.Count];

            foreach (User listUser in ListUsersSave)
            {
                lines[i]= listUser.Name+":"+ listUser.Points+":"+ listUser.Games + ":" + listUser.LastGame;
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
            SqlConnection myConnectionSQL = new SqlConnection("Server=DESKTOP-VKS9AR0\\SQLEXPRESS;Database=ScoreKeeper;Trusted_Connection=True;");
            SqlCommand insertSQL;
            SqlParameter myParamName, myParamPoints, myParamGames, myParamLastGame;
            try
            {
                myConnectionSQL.Open();
                ListUsersSave = List();
              
                myParamName = new SqlParameter("@ParamName", SqlDbType.VarChar, 255);
                myParamName.Value = user.Name;
                myParamPoints = new SqlParameter("@ParamPoints", SqlDbType.Int, 4);
                myParamPoints.Value = user.Points;
                myParamGames = new SqlParameter("@ParamGames", SqlDbType.Int, 4);
                myParamGames.Value = user.Games;
                myParamLastGame = new SqlParameter("@ParamLastGame", SqlDbType.DateTime, 255);
                myParamLastGame.Value = user.LastGame;

                //insertSQL = new SqlCommand("INSERT INTO dbo.score  VALUES (@ParamName, @ParamPoints, @ParamGames)", myConnectionSQL);
                insertSQL = new SqlCommand("EXEC InserUser @Name = @ParamName, @Points = @ParamPoints, @Games = @ParamGames, @LastGame = @ParamLastGame", myConnectionSQL);
                insertSQL.Parameters.Add(myParamName);
                insertSQL.Parameters.Add(myParamPoints);
                insertSQL.Parameters.Add(myParamGames);
                insertSQL.Parameters.Add(myParamLastGame);
                insertSQL.ExecuteNonQuery();
               
                myConnectionSQL.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void InputScoreSQL()
        {
            SqlConnection myConnectionSQL = new SqlConnection("Server=DESKTOP-VKS9AR0\\SQLEXPRESS;Database=ScoreKeeper;Trusted_Connection=True;");
            int points, games;
            DateTime lastGame;
            try
            {
                myConnectionSQL.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM dbo.score", myConnectionSQL);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int.TryParse(myReader["POINTS"].ToString(), out points);
                    int.TryParse(myReader["GAMES"].ToString(), out games);
                    DateTime.TryParse(myReader["LASTGAME"].ToString(), out lastGame);
                    ListUsers.Add(new User(myReader["NAME"].ToString(), points, games, lastGame));
                }
                myConnectionSQL.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

            public void testbdd()
        {
            SqlConnection myConnectionSQL = new SqlConnection("Server=DESKTOP-VKS9AR0\\SQLEXPRESS;Database=ScoreKeeper;Trusted_Connection=True;");
                                     /*   "user id=julien;" +
                                       "password=walki;server=serverurl;" +
                                       "Trusted_Connection=yes;" +
                                       "database=database; " +
                                       "connection timeout=30");*/
            try
            {
                myConnectionSQL.Open();
                System.Diagnostics.Debug.WriteLine("good: ");
                var test = "tes";
                SqlParameter myParam = new SqlParameter("@Param1", SqlDbType.VarChar, 255);
                myParam.Value = test;

                SqlParameter myParam2 = new SqlParameter("@Param2", SqlDbType.Int, 4);
                myParam2.Value = 42;

                SqlParameter myParam3 = new SqlParameter("@Param3", SqlDbType.Int, 4);
                myParam3.Value = 42;

                SqlCommand insertSQL = new SqlCommand("INSERT INTO dbo.score  VALUES (@Param1, @Param2, @Param3)", myConnectionSQL);
                insertSQL.Parameters.Add(myParam);
                insertSQL.Parameters.Add(myParam2);
                insertSQL.Parameters.Add(myParam3);
                insertSQL.ExecuteNonQuery();

                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("SELECT * FROM dbo.score", myConnectionSQL);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader["NAME"].ToString());
                        Console.WriteLine(myReader["POINTS"].ToString());
                        Console.WriteLine(myReader["GAMES"].ToString());
                    }
                    myConnectionSQL.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("bad: ");
                Console.WriteLine(e.ToString());
            }

        }
    }
}