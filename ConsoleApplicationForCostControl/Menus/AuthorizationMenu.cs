using ConsoleApplicationForCostControl.UsersAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class AuthorizationMenu : Menu, IMenu
    {
        private static UserAuthorization userAuthorization = new UserAuthorization();
        public void ShowMenu()
        {
            Console.WriteLine("1 — Log In\n" +
                              "2 — Registration\n");

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
                    userAuthorization.LogIn();
                }
                else if (ChosenNumber == 2)
                {
                    Console.Clear();
                    userAuthorization.Registration();
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
