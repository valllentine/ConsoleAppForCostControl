using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.AddQueries
{
    public class AddRecord : Queries
    {
        public void AddRecordQuery(int category, int day, int month, int year, decimal sum)
        {
            Cost cost = new Cost()
            {
                User_id = userinfo.AuthorizedUserId,
                Category_id = category,
                Date = new DateTime(year, month, day),
                Sum = sum
            };

            db.Costs.Add(cost);
            db.SaveChanges();
        }
    }
}
