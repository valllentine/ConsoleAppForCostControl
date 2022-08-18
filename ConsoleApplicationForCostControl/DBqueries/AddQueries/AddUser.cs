using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.AddQueries
{
    public class AddUser : Queries
    {
        public void AddUserQuery(string name, string password, string email)
        {
            User user = new User()
            {
                Name = name,
                Password = password,
                Email = email
            };

            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
