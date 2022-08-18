using ConsoleApplicationForCostControl.DBqueries.DeleteQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.ShowResults
{
    public class ShowDeleteData : ShowResults
    {
        public void DeleteAllRecords()
        {
            Console.WriteLine("If you want to delete all records, press 1.");
            Console.WriteLine("If you want to return to the menu, press 2.\n");

            int user_input = 0;

            try
            {
                user_input = Convert.ToInt32(Console.ReadLine());

                if (user_input < 1 || user_input > 2)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(INPUT_IS_NOT_IN_RIGHT_FORMAT);
                DeleteAllRecords();
            }

            if(user_input == 1)
            {
                try
                {
                    deleteAllRecords.DeleteAllRecordsQuery();
                    Console.WriteLine("All records were successfully deleted.");
                    returnToMenu.Return(basicMenu);
                }
                catch
                {
                    throw new Exception();
                }
                
            }
            else if(user_input == 2)
            {
                basicMenu.ShowMenu();
            }
        }

    }
}
