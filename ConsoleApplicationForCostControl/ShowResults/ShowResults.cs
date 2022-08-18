using ConsoleApplicationForCostControl.DBqueries.AddQueries;
using ConsoleApplicationForCostControl.DBqueries.DeleteQueries;
using ConsoleApplicationForCostControl.DBqueries.SelectQueries;
using ConsoleApplicationForCostControl.Menus;
using ConsoleApplicationForCostControl.UserInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.ShowResults
{
    public class ShowResults
    {
        #region MenuInstances

        private protected static ReturnToMenu returnToMenu = new ReturnToMenu();
        private protected static SelectMenu selectMenu = new SelectMenu();
        private protected static AddMenu addMenu = new AddMenu();
        private protected static BasicMenu basicMenu = new BasicMenu();
        private protected static DeleteMenu deleteMenu = new DeleteMenu();
        private protected static RecordsByDateMenu recordsByDateMenu = new RecordsByDateMenu();
        private protected static AuthorizationMenu authorizationMenu = new AuthorizationMenu();


        #endregion

        #region UserInputInstances

        private protected static UserInput userInput = new UserInput();

        #endregion

        #region QueriesInstances

        private protected FinalQueryResult selectQueries = new FinalQueryResult();
        private protected SelectAllCosts selectAllCosts = new SelectAllCosts();
        private protected SelectCostsByCategory selectCostsByCategory = new SelectCostsByCategory();
        private protected SelectSumOfCostsInAllCategories selectSumOfCostsForAllCategories = new SelectSumOfCostsInAllCategories();
        private protected SelectCostsByDay selectCostsByDay = new SelectCostsByDay();
        private protected SelectCostsByYear selectCostsByYear = new SelectCostsByYear();
        private protected SelectCostsByMonth selectCostsByMonth = new SelectCostsByMonth();
        private protected AddRecord addRecord = new AddRecord();
        private protected DeleteAllRecords deleteAllRecords = new DeleteAllRecords();

        #endregion

        #region Enums

        private protected enum Categories
        {
            Food = 1,
            Travels,
            Charity,
            Health,
            Entertainment,
            Shopping,
            Electronics,
            Other,
            Beauty
        }

        private protected enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        #endregion

        #region Messages

        private protected const string INFO_TO_RETURN_TO_THE_MENU = "Press Esc to return to the menu.\n";
        private protected const string EMPTY_RESULT = "No data found.";
        private protected const string INPUT_IS_NOT_IN_RIGHT_FORMAT = "Please write the data in the correct format.";

        #endregion

        #region Formats

        private protected const string DATE_FORMAT_OUTPUT = "dd.MM.yyyy";
        private protected const string MONEY_FORMAT_OUTPUT = "{0:C2}";

        #endregion
    }
}
