using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class AddMenu : Menu, IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("1 — Add a record\n" +
                              "2 — Return to basic menu\n");

            CheckInputNumber();
        }

        private void CheckInputNumber()
        {
            try
            {
                ChosenNumber = Convert.ToInt32(Console.ReadLine());

            if (ChosenNumber < 1 || ChosenNumber > 2)
                throw new Exception();

            if (ChosenNumber == 1)
                {
                    Console.Clear();
                    showAddedResults.ShowAddRecord();
                }

                else if (ChosenNumber == 2)
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
