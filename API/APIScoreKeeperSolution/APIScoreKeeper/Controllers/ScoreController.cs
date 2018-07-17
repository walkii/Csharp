using APIScoreKeeper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIScoreKeeper.Controllers
{
    public class ScoreController : ApiController
    {
        Score[] scores = new Score[5];

        public IEnumerable<Score> GetAllScores()
        {
            SqlConnection myConnectionSQL = new SqlConnection("Server=DESKTOP-VKS9AR0\\SQLEXPRESS;Database=ScoreKeeper;Trusted_Connection=True;");
            int id, points, games,i=0;
            try
            {
                myConnectionSQL.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select TOP 5 * FROM score ORDER BY POINTS DESC", myConnectionSQL);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    int.TryParse(myReader["ID"].ToString(), out id);
                    int.TryParse(myReader["POINTS"].ToString(), out points);
                    int.TryParse(myReader["GAMES"].ToString(), out games);
                   
                    scores[i] = new Score { Id = id, Name = myReader["NAME"].ToString(), Points = points, Games = games, LastGame= myReader["LASTGAME"].ToString() };
                    i++;
                }
                myConnectionSQL.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return scores;
        }
        //localhost:63254/api/score
    }
}
