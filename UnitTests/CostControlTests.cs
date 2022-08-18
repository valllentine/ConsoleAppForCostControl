using ConsoleApplicationForCostControl.Database;
using ConsoleApplicationForCostControl.DBqueries.SelectQueries;
using ConsoleApplicationForCostControl.DBqueries;
using ConsoleApplicationForCostControl.Entities;
using ConsoleApplicationForCostControl.UsersAuthorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ConsoleApplicationForCostControl.DBqueries.AddQueries;
using ConsoleApplicationForCostControl.DBqueries.DeleteQueries;

namespace UnitTests
{
    public class CostControlTests
    {
        private class TESTCostControlDBContext : CostControlDBContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\matil\\source\\repos\\ConsoleApplicationForCostControl\\UnitTests\\TESTCostControlDB.mdf;Integrated Security=True");
                }
            }
        }
        private TESTCostControlDBContext db = new TESTCostControlDBContext();
        private AuthorizedUserInformation userinfo = new AuthorizedUserInformation();


        List<Cost> test_costs;
        List<Cost> expected_costs;
        List<Category> categories;

        #region Instances

        private FinalQueryResult selectQueries = new FinalQueryResult();
        private SelectAllCosts selectAllCosts = new SelectAllCosts();
        private SelectCostsByCategory selectCostsByCategory = new SelectCostsByCategory();
        private SelectSumOfCostsInAllCategories selectSumOfCostsInAllCategories = new SelectSumOfCostsInAllCategories();
        private SelectCostsByDay selectCostsByDay = new SelectCostsByDay();
        private SelectCostsByMonth selectCostsByMonth = new SelectCostsByMonth();   
        private SelectCostsByYear selectCostsByYear = new SelectCostsByYear();
        private AddRecord addRecord = new AddRecord();
        private AddUser addUser = new AddUser();
        private DeleteAllRecords deleteAllRecords = new DeleteAllRecords();

        #endregion

        #region SelectTests

        [Fact]
        private void Test_SelectAllCosts()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();
            CreateCategoriesList();
            Expected_SelectAllCosts();

            var actual_result = selectQueries.FinalCostsQueryResult(selectAllCosts);

            for (int i = 0; i < test_costs.Count; i++)
            {

                Assert.Equal(expected_costs[i].Sum, actual_result[i].Sum);
                Assert.Equal(expected_costs[i].Date, actual_result[i].Date);
                Assert.Equal(categories[Convert.ToInt32((expected_costs[i].Category_id)) - 1].Category_name, actual_result[i].Category.Category_name);
            }
            DeleteTestDataFromCostsTable();
        }

        [Fact]
        private void Test_SelectSumOfCostsInAllCategories()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();
            CreateCategoriesList();
            Expected_SelectSumOfCostsInAllCategories();

            var actual_result = selectQueries.FinalCostsQueryResult(selectSumOfCostsInAllCategories);

            for (int i = 0; i < expected_costs.Count; i++)
            {

                Assert.Equal(expected_costs[i].Sum, actual_result[i].Sum);
                Assert.Equal(categories[Convert.ToInt32((expected_costs[i].Category_id)) - 1].Category_name, actual_result[i].Category.Category_name);
            }

            DeleteTestDataFromCostsTable();
        }

        [Fact]
        private void Test_SelectAllCostsByCategory()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();
            Expected_SelectAllCostsByCategory();

            int category_id = 1;
            var actual_result = selectQueries.FinalCostsQueryResult(selectCostsByCategory, category_id);

            for (int i = 0; i < expected_costs.Count; i++)
            {

                Assert.Equal(expected_costs[i].Sum, actual_result[i].Sum);
                Assert.Equal(expected_costs[i].Date, actual_result[i].Date);
            }

            DeleteTestDataFromCostsTable();
        }

        [Fact]
        private void Test_SelectCostsByDay()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();
            CreateCategoriesList();
            Expected_SelectCostsByDay();

            var actual_result = selectQueries.FinalCostsQueryResult(selectCostsByDay, 11, 11, 2019);

            for (int i = 0; i < expected_costs.Count; i++)
            {

                Assert.Equal(expected_costs[i].Sum, actual_result[i].Sum);
                Assert.Equal(categories[Convert.ToInt32((expected_costs[i].Category_id)) - 1].Category_name, actual_result[i].Category.Category_name);
            }

            DeleteTestDataFromCostsTable();
        }

        [Fact]
        private void Test_SelectCostsByMonth()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();
            CreateCategoriesList();
            Expected_SelectCostsByMonth();

            var actual_result = selectQueries.FinalCostsQueryResult(selectCostsByMonth, 11, 2019);

            for (int i = 0; i < expected_costs.Count; i++)
            {

                Assert.Equal(expected_costs[i].Sum, actual_result[i].Sum);
                Assert.Equal(categories[Convert.ToInt32((expected_costs[i].Category_id)) - 1].Category_name, actual_result[i].Category.Category_name);
            }

            DeleteTestDataFromCostsTable();
        }

        [Fact]
        private void Test_SelectCostsByYear()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();
            CreateCategoriesList();
            Expected_SelectCostsByYear();

            var actual_result = selectQueries.FinalCostsQueryResult(selectCostsByYear, 2019);

            for (int i = 0; i < expected_costs.Count; i++)
            {

                Assert.Equal(expected_costs[i].Sum, actual_result[i].Sum);
                Assert.Equal(categories[Convert.ToInt32((expected_costs[i].Category_id)) - 1].Category_name, actual_result[i].Category.Category_name);
            }

            DeleteTestDataFromCostsTable();
        }

        #endregion

        #region SelectExpectedResults
        private void Expected_SelectAllCosts()
        {
            expected_costs = new List<Cost>
            {
                new Cost
                {
                    Sum = 500,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 1,
                    User_id = 1
                },

                new Cost
                {
                    Sum = 100,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 3,
                    User_id = 1

                },

                 new Cost
                 {
                    Sum = 20,
                    Date = new DateTime(2015, 9, 9),
                    Category_id = 1,
                    User_id = 1
                 }
            };
        }

        private void Expected_SelectAllCostsByCategory()
        {
            expected_costs = new List<Cost>
            {
                new Cost
                {
                    Sum = 500,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 1,
                    User_id = 1
                },

                 new Cost
                 {
                    Sum = 20,
                    Date = new DateTime(2015, 9, 9),
                    Category_id = 1,
                    User_id = 1
                 }
            };
        }

        private void Expected_SelectSumOfCostsInAllCategories()
        {
            expected_costs = new List<Cost>
            {
                new Cost
                {
                    Sum = 520,
                    Category_id = 1,
                },

                new Cost
                {
                    Sum = 100,
                    Category_id = 3,

                }
            };
        }

        private void Expected_SelectCostsByDay()
        {
            expected_costs = new List<Cost>
            {
                new Cost
                {
                    Sum = 500,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 1,
                    User_id = 1
                },

                new Cost
                {
                    Sum = 100,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 3,
                    User_id = 1

                }
            };
        }

        private void Expected_SelectCostsByMonth()
        {
            expected_costs = new List<Cost>
            {
                new Cost
                {
                    Sum = 500,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 1,
                    User_id = 1
                },

                new Cost
                {
                    Sum = 100,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 3,
                    User_id = 1

                }
            };
        }

        private void Expected_SelectCostsByYear()
        {
            expected_costs = new List<Cost>
            {
                new Cost
                {
                    Sum = 500,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 1,
                    User_id = 1
                },

                new Cost
                {
                    Sum = 100,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 3,
                    User_id = 1

                }
            };
        }


        #endregion

        #region AddTests

        [Fact]
        private void Test_AddRecord()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            int expected_category = 1;
            int expected_day = 20;
            int expected_month = 12;
            int expected_year = 2020;
            int expected_sum = 250;

            addRecord.AddRecordQuery(1, 20, 12, 2020, 250);

            var actual_result = from c in db.Costs
                                select c;

            Assert.Equal(expected_category, actual_result.First().Category_id);
            Assert.Equal(expected_day, actual_result.First().Date.Day);
            Assert.Equal(expected_month, actual_result.First().Date.Month);
            Assert.Equal(expected_year, actual_result.First().Date.Year);
            Assert.Equal(expected_sum, actual_result.First().Sum);

            DeleteTestDataFromCostsTable();
        }

        [Fact]
        private void Test_AddUser()
        {
            Queries.db = db;

            string expected_name = "Ted";
            string expected_password = "111";
            string expected_email = "ted@gmail.com";

            addUser.AddUserQuery(expected_name, expected_password, expected_email);

            var actual_result = from c in db.Users
                                where c.Name == expected_name
                                select c;

            Assert.Equal(expected_name, actual_result.First().Name);
            Assert.Equal(expected_password, actual_result.First().Password);
            Assert.Equal(expected_email, actual_result.First().Email);

            var user_to_delete = from c in db.Users
                                 where c.Name == expected_name
                                 select c;

            db.Users.RemoveRange(user_to_delete);
            db.SaveChanges();
        }

        #endregion

        #region DeleteTest

        [Fact]
        private void Test_DeleteAllRecords()
        {
            Queries.db = db;
            userinfo.AuthorizedUserId = 1;

            CreateTestDataInCostsTable();

            deleteAllRecords.DeleteAllRecordsQuery();
        }

        #endregion

        #region CreateAndDeleteTestData

        private void CreateTestDataInCostsTable()
        {
            test_costs = new List<Cost>()
            {
                new Cost
                {
                    Sum = 500,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 1,
                    User_id = 1
                },

                new Cost
                {
                    Sum = 100,
                    Date = new DateTime(2019, 11, 11),
                    Category_id = 3,
                    User_id = 1

                },

                 new Cost
                 {
                    Sum = 20,
                    Date = new DateTime(2015, 9, 9),
                    Category_id = 1,
                    User_id = 1
                 }
            };

            Queries.db = db;

            for (int i = 0; i < test_costs.Count; i++)
            {
                db.Costs.Add(test_costs[i]);
                db.SaveChanges();
            }
        }

        private void DeleteTestDataFromCostsTable()
        {
            Queries.db = db;

            var all_data = from c in db.Costs select c;
            db.Costs.RemoveRange(all_data);
            db.SaveChanges();

        }

        private void CreateCategoriesList()
        {
            categories = new List<Category>
            {
                    new Category
                    {
                        Id = 1,
                        Category_name = "Food"
                    },

                    new Category
                    {
                        Id = 2,
                        Category_name = "Shopping"
                    },

                    new Category
                    {
                        Id = 3,
                        Category_name = "Charity"
                    }
            };
        }

        #endregion CreateAndDeleteTestData
    }
}
