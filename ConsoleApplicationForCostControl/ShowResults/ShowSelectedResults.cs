using ConsoleApplicationForCostControl.DBqueries.SelectQueries;
using ConsoleApplicationForCostControl.Entities;
using ConsoleApplicationForCostControl.Menus;
using ConsoleApplicationForCostControl.UserInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.ShowResults
{
    public class ShowSelectedResults : ShowResults
    {
        public void ShowSelectAllCosts()
        {
            var result = selectQueries.FinalCostsQueryResult(selectAllCosts);

            Console.WriteLine($"Spending in all category:\n");

            if (!result.Any())
                Console.WriteLine(EMPTY_RESULT);
            else
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"{res.Category.Category_name} — " +
                                      $"{string.Format(MONEY_FORMAT_OUTPUT, res.Sum)} — " +
                                      $"{res.Date.ToString(DATE_FORMAT_OUTPUT)}");
                }
            }

            returnToMenu.Return(selectMenu);
        }

        public void ShowSumOfAllCategories()
        {
            var result = selectQueries.FinalCostsQueryResult(selectSumOfCostsForAllCategories);

            Console.WriteLine($"Spending from all categories:\n");

            if (!result.Any())
                Console.WriteLine(EMPTY_RESULT);
            else
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"{res.Category.Category_name} — {string.Format(MONEY_FORMAT_OUTPUT, res.Sum)}");
                }
            }

            returnToMenu.Return(selectMenu);
        }

        public void ShowSelectCostsByCategory()
        {
            Console.WriteLine("Select a category number from the list of categories:");

            int num = 1;
            foreach (Categories suit in (Categories[])Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{num} — {suit}");
                num++;
            }

            int user_category = 0;
            try
            {
                user_category = userInput.CategoryInput();
                
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(INPUT_IS_NOT_IN_RIGHT_FORMAT);
                ShowSelectCostsByCategory();
            }

            var result = selectQueries.FinalCostsQueryResult(selectCostsByCategory, user_category);
            Console.Clear();
            Console.WriteLine($"Spending in the category {(Categories)user_category}:\n");

            if (!result.Any())
                Console.WriteLine(EMPTY_RESULT);
            else
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"{string.Format(MONEY_FORMAT_OUTPUT, res.Sum)} — " +
                                      $"{res.Date.ToString(DATE_FORMAT_OUTPUT)}");
                }
            }

            returnToMenu.Return(selectMenu);
        }

        public void ShowSelectCostsByDay()
        {
            Console.WriteLine("Enter data in the following format: dd/mm/yyyy or dd-mm-yyyy\n");

            DateTime user_date = new DateTime();
            try
            {
                user_date = userInput.DayInput();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(INPUT_IS_NOT_IN_RIGHT_FORMAT);
                ShowSelectCostsByDay();
            }

            int user_day = user_date.Day;
            int user_month = user_date.Month;
            int user_year = user_date.Year;

            var result = selectQueries.FinalCostsQueryResult(selectCostsByDay, user_day, user_month, user_year);

            Console.Clear();
            Console.WriteLine($"Date: " + user_date.ToString(DATE_FORMAT_OUTPUT) + "\n");

            if (!result.Any())
                Console.WriteLine(EMPTY_RESULT);
            else
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"{res.Category.Category_name} — {string.Format(MONEY_FORMAT_OUTPUT, res.Sum)}");
                }
            }

            returnToMenu.Return(recordsByDateMenu);
        }

        public void ShowSelectCostsByMonth()
        {
            int user_month = 0;
            int user_year = 0;

            try
            {
                Console.WriteLine("Enter the Month in the following format: mm. Press Enter\n");
                user_month = userInput.MonthInput();

                Console.WriteLine("Enter the Year in the following format: yyyy. Press Enter\n");
                user_year = userInput.YearInput();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(INPUT_IS_NOT_IN_RIGHT_FORMAT);
                ShowSelectCostsByMonth();
            }

            var result = selectQueries.FinalCostsQueryResult(selectCostsByMonth, user_month, user_year);

            Console.Clear();
            Console.WriteLine($"Date: " + Enum.GetName(typeof(Months), user_month).ToString() + " " + user_year + "\n");

            if (!result.Any())
                Console.WriteLine(EMPTY_RESULT);
            else
            {
                foreach (var res in result)
                {
                    Console.WriteLine($"{res.Category.Category_name} — {string.Format(MONEY_FORMAT_OUTPUT, res.Sum)}");
                }
            }
            returnToMenu.Return(recordsByDateMenu);
        }

        public void ShowSelectCostsByYear()
        {
            Console.WriteLine("Enter data in the following format: yyyy\n");

            int user_year = 0;
            try
            {
                user_year = userInput.YearInput();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(INPUT_IS_NOT_IN_RIGHT_FORMAT);
                ShowSelectCostsByYear();
            }
            var result = selectQueries.FinalCostsQueryResult(selectCostsByYear, user_year);

            Console.Clear();
            Console.WriteLine($"Year: " + user_year + "\n");

            if (!result.Any())
                Console.WriteLine(EMPTY_RESULT);
            else
            {
                foreach (var res in result)
                    Console.WriteLine($"{res.Category.Category_name} — {string.Format(MONEY_FORMAT_OUTPUT, res.Sum)}");
            }

            returnToMenu.Return(recordsByDateMenu);
        }
    }
}
