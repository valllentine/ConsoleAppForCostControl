using ConsoleApplicationForCostControl.DBqueries.AddQueries;
using ConsoleApplicationForCostControl.DBqueries.SelectQueries;
using ConsoleApplicationForCostControl.ShowResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Menus
{
    public abstract class Menu
    {
        #region Exeptions

        public const string WRONG_INPUT_BY_USER = "Wrong input! Select a number from the list!";

        #endregion

        #region MenuInstances

        private protected static ReturnToMenu returnToMenu = new ReturnToMenu();
        private protected static SelectMenu selectMenu = new SelectMenu();
        private protected static AddMenu addMenu = new AddMenu();
        private protected static BasicMenu basicMenu = new BasicMenu();
        private protected static DeleteMenu deleteMenu = new DeleteMenu();
        private protected static RecordsByDateMenu recordsByDateMenu = new RecordsByDateMenu();
        private protected static AuthorizationMenu authorizationMenu = new AuthorizationMenu();

        #endregion

        #region ShowDataInstances

        private protected ShowSelectedResults showSelectedResults = new ShowSelectedResults();
        private protected ShowAddedResults showAddedResults = new ShowAddedResults();
        private protected ShowDeleteData showDeleteData = new ShowDeleteData();

        #endregion

        private protected FinalQueryResult selectQueries = new FinalQueryResult();
        public int ChosenNumber { get; set; }

    }
}
