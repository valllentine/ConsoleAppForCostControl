using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public class SelectCostsByYear : Queries, ISelectCostsQuery
    {
        public IQueryable<Cost> ReturnLinqResult(params int[] userInput)
        {
            var result = from ct in db.Costs
                          where ct.Date.Year == userInput.First()
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
