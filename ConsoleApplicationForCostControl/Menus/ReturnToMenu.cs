using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public class ReturnToMenu
    {
        public void Return(IMenu menu)
        {
            Console.WriteLine();
            Console.WriteLine("Press Esc to return to the menu.");

            while (Console.ReadKey().Key != ConsoleKey.Escape) { };

            Console.WriteLine("A"); //For normal data display after ReadKey
            Console.Clear();
            menu.ShowMenu();
        }
    }
}
