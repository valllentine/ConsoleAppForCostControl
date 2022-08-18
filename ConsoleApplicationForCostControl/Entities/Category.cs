using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Category_name { get; set; }

    }
}
  