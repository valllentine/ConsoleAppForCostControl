using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{

    public class SelectAllUsers : Queries, ISelectUsersQuery
    {
        public IQueryable<User> ReturnLinqResult(params string[] userInput)
        {
            var result = from ct in db.Users
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
