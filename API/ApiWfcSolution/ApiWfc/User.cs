using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWfc
{
    public class User
    {

        private string namePrivate;
        private int pointsPrivate;
        private int gamesPrivate;

        public User()
        {
            namePrivate = "Groot";
            pointsPrivate = 100;
            gamesPrivate = 1;
        }

        public User(string name, int points)
        {
            namePrivate = name;
            pointsPrivate = points;
            gamesPrivate = 1;
        }

        public User(string name, int points, int games)
        {
            namePrivate = name;
            pointsPrivate = points;
            gamesPrivate = games;
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
    }
}