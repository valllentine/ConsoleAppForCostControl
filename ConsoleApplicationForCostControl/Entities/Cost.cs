using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Entities
{
    public class Cost
    {

        public int Id { get; set; }
        public int Category_id { get; set; }
        public int User_id { get; set; }
        public decimal Sum  { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Category_id")]
        public Category Category { get; set; }

        [ForeignKey("User_id")]
        public User User { get; set; }

    }
}
