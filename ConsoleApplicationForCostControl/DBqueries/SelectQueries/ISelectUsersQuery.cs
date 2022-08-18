using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public interface ISelectUsersQuery
    {
        public IQueryable<User> ReturnLinqResult(params string[] userInput);
    }
}
