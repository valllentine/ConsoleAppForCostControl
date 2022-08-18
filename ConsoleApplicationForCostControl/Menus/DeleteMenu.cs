using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class DeleteMenu : Menu, IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("1 — Delete all records \n" +
                              "2 — Return to menu\n");

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
                    showDeleteData.DeleteAllRecords();
                }

                if (ChosenNumber == 2)
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
