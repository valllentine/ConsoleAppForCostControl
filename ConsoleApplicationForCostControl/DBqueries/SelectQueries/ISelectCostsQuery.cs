using ConsoleApplicationForCostControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public interface ISelectCostsQuery
    {
        public IQueryable<Cost> ReturnLinqResult(params int[] userInput);
    }
}
