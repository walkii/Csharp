using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ApiWfc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Calculate calculate = new Calculate();
        public string GetList()
        {
           // var calculate = new Calculate();
            List<User> ListUsers;
            //calculate.InputScore();
            ListUsers =calculate.List();
            if (ListUsers.Count==0)
            {
                calculate.InputScore();
                ListUsers = calculate.List();
            }
            string outputScore="";
            System.Diagnostics.Debug.WriteLine("bad: " + ListUsers.Count);
            foreach (User list in ListUsers)
            {
                //System.Diagnostics.Debug.WriteLine("bad: " + list.Name);
                outputScore =outputScore + list.Name+":"+list.Points+":"+list.Games+";";
            }
            return outputScore;
        }

        public bool SetUser(string dataUser)
        {
            //var calculate = new Calculate();
            string[] lineSplit;
            Char delimiter = ':';
            int points;
            lineSplit = dataUser.Split(delimiter);
            int.TryParse(lineSplit[1], out points);
            calculate.AddUser(lineSplit[0], points);
            //ListUsers.Add(new User(lineSplit[0], points));
            return true;
        }
    }
}
