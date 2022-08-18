using ConsoleApplicationForCostControl.DBqueries.AddQueries;
using ConsoleApplicationForCostControl.UserInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.ShowResults
{
    public class ShowAddedResults : ShowResults
    {
        private static ShowSelectedResults showSelectedResults = new ShowSelectedResults();
        public void ShowAddRecord()
        {
            Console.WriteLine("To create a record, enter the data according to the instructions below.\n");
            Console.WriteLine("Select a category number from the list of categories:");

            int num = 1;
            foreach (Categories suit in (Categories[])Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{num} — {suit}");
                num++;
            }

            int user_category = 0;
            DateTime user_date = new DateTime();
            decimal user_sum = 0;

            try
            {
                //GET USER CATEGORY
                user_category = userInput.CategoryInput();

                //GET USER DATE
                Console.WriteLine("Enter data in the following format: dd/mm/yyyy or dd-mm-yyyy");
                user_date = userInput.DayInput();

                Console.WriteLine();

                //GET USER SUM
                Console.WriteLine("Enter the sum:");
                user_sum = userInput.SumInput();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(INPUT_IS_NOT_IN_RIGHT_FORMAT);
                ShowAddRecord();
            }

            int user_day = user_date.Day;
            int user_month = user_date.Month;
            int user_year = user_date.Year;

            try
            {
                addRecord.AddRecordQuery(user_category, user_day, user_month, user_year, user_sum);
            }
            catch
            {
                throw new Exception();
            }

            Console.WriteLine();
            showSelectedResults.ShowSelectAllCosts();

            returnToMenu.Return(basicMenu);
        }
    }
}
