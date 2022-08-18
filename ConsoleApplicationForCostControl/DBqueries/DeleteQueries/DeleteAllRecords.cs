using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.DBqueries.DeleteQueries
{
    public class DeleteAllRecords : Queries
    {
        public void DeleteAllRecordsQuery()
        {
            var data_to_delete = from c in db.Costs
                                 where c.User_id == userinfo.AuthorizedUserId
                                 select c;

            db.Costs.RemoveRange(data_to_delete);
            db.SaveChanges();

        }
    }
}
