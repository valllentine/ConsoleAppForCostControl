using ConsoleApplicationForCostControl.Database;
using ConsoleApplicationForCostControl.Entities;
using ConsoleApplicationForCostControl.UsersAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries
{
    public class Queries
    {
        public static CostControlDBContext db = new CostControlDBContext();
        public static AuthorizedUserInformation userinfo = new AuthorizedUserInformation();

        private protected enum Categories
        {
            Food = 1,
            Travels,
            Charity,
            Health,
            Entertainment,
            Shopping,
            Electronics,
            Other,
            Beauty
        }

        private protected enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

    }
}