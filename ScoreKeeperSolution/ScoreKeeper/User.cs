using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreKeeper
{
    class User
    {
       
        private string NamePrivate;
        private int PointsPrivate;
        private int GamesPrivate;

        public User()
        {
            NamePrivate = "Groot";
            PointsPrivate = 100;
            GamesPrivate = 1;
        }

        public User(string name, int points)
        {
            NamePrivate = name;
            PointsPrivate = points;
            Games = 1;
        }

        public string Name
        {
            get
            {
                return NamePrivate;
            }
            set
            {
                NamePrivate = value;
            }
        }
        public int Points
        {
            get
            {
                return PointsPrivate;
            }
            set
            {
                PointsPrivate = value;
            }
        }

        public int Games
        {
            get
            {
                return GamesPrivate;
            }
            set
            {
                GamesPrivate = value;
            }
        }

    }
}
