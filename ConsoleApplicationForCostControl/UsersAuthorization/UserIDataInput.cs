using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.UsersAuthorization
{
    public class UserDataInput
    {
        public string UsernameInput()
        {
            Console.WriteLine("Enter username:");
            string username_input = Console.ReadLine();

            return username_input;
        }

        public string PasswordInput()
        {
            Console.WriteLine("Enter password:");
            string password_input = Console.ReadLine();

            return password_input;
        }
        
        public string EmailInput()
        {
            Console.WriteLine("Enter Email:");
            string email_input = Console.ReadLine();

            return email_input;
        }
    }
}

