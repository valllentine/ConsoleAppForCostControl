using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public class SelectCostsByDay : Queries, ISelectCostsQuery
    {
        public IQueryable<Cost> ReturnLinqResult(params int[] userInput)
        {
            int user_day = userInput[0];
            int user_month = userInput[1];
            int user_year = userInput[2];

            var result = from ct in db.Costs
                         where ct.Date.Day == user_day 
                         && ct.Date.Month == user_month 
                         && ct.Date.Year == user_year 
                         && ct.User_id == userinfo.AuthorizedUserId
                         group ct by ct.Category_id into g
                          select new Cost
                          {
                              Sum = g.Sum(t => t.Sum),
                              Category = new Category
                              {
                                  Category_name = (from p in g
                                                   join ctg in db.Categories
                                                   on g.Key equals ctg.Id
                                                   select ctg.Category_name).First().ToString()
                              }
                          };

            return result;
        }
    }
}
