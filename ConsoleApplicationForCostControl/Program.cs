using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ConsoleApplicationForCostControl.Entities;
using ConsoleApplicationForCostControl.Menus;
using ConsoleApplicationForCostControl.Database;

namespace ConsoleApplicationForCostControl
{
    class Programm
    {
        static void Main(string[] args)
        {
            using (CostControlDBContext db = new CostControlDBContext())
            {
                AuthorizationMenu authorizationMenu = new AuthorizationMenu();
                authorizationMenu.ShowMenu();

                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }
            Console.ReadKey();

        }
    }
}
