using ConsoleApplicationForCostControl.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class BasicMenu : Menu, IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("1 — View records\n" +
                              "2 — Make records\n" +
                              "3 — Delete records\n" +
                              "4 — Sign out\n");

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
                    selectMenu.ShowMenu();
                }
                else if (ChosenNumber == 2)
                {
                    Console.Clear();
                    addMenu.ShowMenu();
                }
                else if (ChosenNumber == 3)
                {
                    Console.Clear();
                    deleteMenu.ShowMenu();
                }
                else if (ChosenNumber == 4)
                {
                    Console.Clear();
                    authorizationMenu.ShowMenu();
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
