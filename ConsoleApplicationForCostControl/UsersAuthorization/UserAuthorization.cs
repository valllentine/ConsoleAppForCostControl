using ConsoleApplicationForCostControl.DBqueries.AddQueries;
using ConsoleApplicationForCostControl.DBqueries.SelectQueries;
using ConsoleApplicationForCostControl.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.UsersAuthorization
{
    public class UserAuthorization
    {
        #region Exceptions

        private protected const string USER_ALREADY_EXISTS = "A user with this name already exists.\n";
        private protected const string MESSAGE_ENTER_ANOTHER_NAME = "Please enter another name.\n";
        private protected const string MESSAGE_USER_ACC_CREATED_SUCCESS = "Your account was successfully created\n";
        private protected const string UNEXPECTED_ERROR = "Unexpected error. Try again.\n";

        #endregion

        #region Instances

        private protected static AddUser addUser = new AddUser();
        private protected static ReturnToMenu returnToMenu = new ReturnToMenu();
        private protected static UserDataInput input = new UserDataInput();
        private protected static BasicMenu basicMenu = new BasicMenu();
        private protected static FinalQueryResult selectQueries = new FinalQueryResult();
        private protected static SelectAllUsers selectAllUsers = new SelectAllUsers();
        private protected static SelectUserData selectUserData = new SelectUserData();
        private protected static AuthorizationMenu authorizationMenu = new AuthorizationMenu();

        #endregion

        public void LogIn()
        {
            string username_input = input.UsernameInput();
            string password_input = input.PasswordInput();

            var users = selectQueries.FinalUserQueryResult(selectUserData, username_input, password_input);

            if (!users.Any())
            {
                Console.WriteLine("Username or password entered incorrectly.\n");
                returnToMenu.Return(authorizationMenu);
            }

            else
            {
                AuthorizedUserInformation authorizedUserInformation = new AuthorizedUserInformation();
                authorizedUserInformation.AuthorizedUserId = users.First().Id;

                Console.Clear();
                basicMenu.ShowMenu();

            }
        }

        public void Registration()
        {
            string username_input = input.UsernameInput();
            var all_users = selectQueries.FinalUserQueryResult(selectAllUsers);

            foreach (var user in all_users)
            {
                if (user.Name == username_input)
                {   
                    Console.WriteLine(USER_ALREADY_EXISTS);
                    Console.WriteLine(MESSAGE_ENTER_ANOTHER_NAME);
                    Registration();
                }
            }

            string password_input = input.PasswordInput();
            string email_input = input.EmailInput();

            try
            {
                addUser.AddUserQuery(username_input, password_input, email_input);
                Console.Clear();
                Console.WriteLine(MESSAGE_USER_ACC_CREATED_SUCCESS);
                returnToMenu.Return(authorizationMenu);
            }
            catch
            {
                Console.WriteLine(UNEXPECTED_ERROR);
                authorizationMenu.ShowMenu();
            }
        }

    }
}
