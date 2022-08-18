using ConsoleApplicationForCostControl.Entities;
using ConsoleApplicationForCostControl.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConsoleApplicationForCostControl.DBqueries.SelectQueries
{
    public class FinalQueryResult
    {
        public List<Cost> FinalCostsQueryResult(ISelectCostsQuery query, params int[] userInput)
        {
            List<Cost> result = new List<Cost>();

            var data = query.ReturnLinqResult(userInput);

            if (!data.Any())
                return result;
            else
            {
                foreach (var cost in data)
                {
                    result.Add(new Cost
                    {
                        Sum = cost.Sum,
                        Date = cost.Date,
                        Category_id = cost.Category_id,
                        User_id = cost.User_id,
                        Category = new Category
                        {
                            Category_name = cost.Category.Category_name,
                            Id = cost.Category_id
                        }
                    });
                }
                return result;
            }
        }

        public List<User> FinalUserQueryResult(ISelectUsersQuery query, params string[] userInput)
        {
            List<User> result = new List<User>();

            var users = query.ReturnLinqResult(userInput);

            if (!users.Any())
                return result;
            else
            {
                foreach (var user in users)
                {
                    result.Add(new User
                    {
                       Id = user.Id,
                       Name = user.Name,
                       Password = user.Password,
                       Email = user.Email

                    });
                }
                return result;
            }
        }

    }
}
