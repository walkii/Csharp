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
                System.Diagnostics.Debug.WriteLine("good: " + TryUser);
                ListUsers.Add(new User(name, points));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("TryUser: " + TryUser);
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
    }
}
