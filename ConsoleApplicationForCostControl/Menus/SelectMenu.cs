using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class SelectMenu : Menu, IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("1 — Select records from all categoris\n" +
                              "2 — Select records from one category\n" +
                              "3 — Select sum of costs from all categories\n" +
                              "4 — Select records by date\n" +
                              "5 — Return to basic menu\n");

            CheckInputNumber();
        }

        private void CheckInputNumber()
        {
            try
            {
                ChosenNumber = Convert.ToInt32(Console.ReadLine());

                if (ChosenNumber < 1 || ChosenNumber > 5)
                    throw new Exception();

                if (ChosenNumber == 1)
                {
                    Console.Clear();
                    showSelectedResults.ShowSelectAllCosts();
                }

                else if (ChosenNumber == 2)
                {
                    Console.Clear();
                    showSelectedResults.ShowSelectCostsByCategory();
                }

                else if (ChosenNumber == 3)
                {
                    Console.Clear();
                    showSelectedResults.ShowSumOfAllCategories();
                }

                else if (ChosenNumber == 4)
                {
                    Console.Clear();
                    recordsByDateMenu.ShowMenu();
                }
                else if (ChosenNumber == 5)
                {
                    Console.Clear();
                    basicMenu.ShowMenu();
                }
            }

            catch
            {
                Console.WriteLine(WRONG_INPUT_BY_USER);
                CheckInputNumber();
            }
        }
    }
}
