using ConsoleApplicationForCostControl.DBqueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class RecordsByDateMenu : Menu, IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("1 — Select records by day\n" +
                              "2 — Select records by month\n" +
                              "3 — Select records by year\n" +
                              "4 — Return to basic menu\n");

            CheckInputNumber();
        }

        private void CheckInputNumber()
        {
            try
            {
                ChosenNumber = Convert.ToInt32(Console.ReadLine());

                if (ChosenNumber < 1 || ChosenNumber > 4)
                    throw new Exception();

                if (ChosenNumber == 1)
                {
                    Console.Clear();
                    showSelectedResults.ShowSelectCostsByDay();
                }

                else if (ChosenNumber == 2)
                {
                    Console.Clear();
                    showSelectedResults.ShowSelectCostsByMonth();
                }

                else if (ChosenNumber == 3)
                {
                    Console.Clear();
                    showSelectedResults.ShowSelectCostsByYear();
                }

                else if (ChosenNumber == 4)
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
