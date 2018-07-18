using APIScoreKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIScoreKeeper.Controllers
{
    public class ScoreController : ApiController
    {
        Score[] scores = new Score[5];

        public IEnumerable<Score> GetAllScores()
        {
            int i = 0;
            using (var db = new ScoreKeeperAPIContext())
            {
                var query = (from b in db.scores orderby b.POINTS descending select b).Take(5);

                foreach (var item in query)
                {
                    scores[i] = new Score { Id = item.ID, Name = item.NAME, Points = item.POINTS, Games = item.GAMES, LastGame = item.LASTGAME };
                    i++;
                }
            }
                return scores;
        }
        //localhost:63254/api/score
    }
}
