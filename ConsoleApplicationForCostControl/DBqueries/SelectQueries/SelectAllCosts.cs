using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public class SelectAllCosts : Queries, ISelectCostsQuery
    {
        public IQueryable<Cost> ReturnLinqResult(params int[] userInput)
        {
            var result = from ct in db.Costs
                         where ct.User_id == userinfo.AuthorizedUserId
                         join ctg in db.Categories
                         on ct.Category_id equals ctg.Id
                         select new Cost
                         {
                              Date = ct.Date,
                              Sum = ct.Sum,
                              Category_id = ct.Category_id,
                              User_id = ct.User_id,

                              Category = new Category
                              {
                                  Category_name = ctg.Category_name,
                              }
                         };

            return result;
        }
    }
}
