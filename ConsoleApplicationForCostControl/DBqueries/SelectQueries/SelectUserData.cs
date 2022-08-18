using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public class SelectUserData : Queries, ISelectUsersQuery
    {
        public IQueryable<User> ReturnLinqResult(params string[] userInput)
        {
            string username = userInput[0];
            string password = userInput[1];

            var result = from ct in db.Users
                         where ct.Name == username && ct.Password == password
                         select new User
                         {
                             Id = ct.Id,
                             Name = ct.Name,
                             Password = ct.Password,
                             Email = ct.Email
                         };

            return result;
        }
    }
}
