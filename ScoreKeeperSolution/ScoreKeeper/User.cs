using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreKeeper
{
    class User
    {
       
        private string namePrivate;
        private int pointsPrivate;
        private int gamesPrivate;
        private DateTime lastGamePrivate;

        public User()
        {
            namePrivate = "Groot";
            pointsPrivate = 100;
            gamesPrivate = 1;
            lastGamePrivate = DateTime.Now;
        }

        public User(string name, int points)
        {
            namePrivate = name;
            pointsPrivate = points;
            gamesPrivate = 1;
            lastGamePrivate = DateTime.Now;
        }

        public User(string name, int points, int games, DateTime date)
        {
            namePrivate = name;
            pointsPrivate = points;
            gamesPrivate = games;
            lastGamePrivate = date;
        }

        public string Name
        {
            get
            {
                return namePrivate;
            }
            set
            {
                namePrivate = value;
            }
        }
        public int Points
        {
            get
            {
                return pointsPrivate;
            }
            set
            {
                pointsPrivate = value;
            }
        }

        public int Games
        {
            get
            {
                return gamesPrivate;
            }
            set
            {
                gamesPrivate = value;
            }
        }

        public DateTime LastGame
        {
            get
            {
                return lastGamePrivate;
            }
            set
            {
                lastGamePrivate = value;
            }
        }

    }
}