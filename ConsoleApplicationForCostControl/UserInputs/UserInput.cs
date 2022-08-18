using ConsoleApplicationForCostControl.ShowResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.UserInputs
{
    public class UserInput
    {
        #region Exeptions

        private protected const string INPUT_IS_NOT_IN_RIGHT_FORMAT = "Please write the data in the correct format.";

        #endregion

        public int CategoryInput()
        {
            int user_category;

            try
            {
                user_category = Convert.ToInt32(Console.ReadLine());

                if (user_category < 1 || user_category > 9)
                {
                    throw new Exception();
                }
            }

            catch
            {
                throw new Exception(INPUT_IS_NOT_IN_RIGHT_FORMAT);
            }

            return user_category;
        }

        public DateTime DayInput()
        {
            DateTime user_day_dt;

            try
            {
                user_day_dt = DateTime.Parse(Console.ReadLine());
            }

            catch
            {
                throw new Exception(INPUT_IS_NOT_IN_RIGHT_FORMAT);
            }

            return user_day_dt;
        }

        public int MonthInput()
        {
            int user_month;

            try
            {
                user_month = Convert.ToInt32(Console.ReadLine());

                if (user_month < 1 || user_month > 12)
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception(INPUT_IS_NOT_IN_RIGHT_FORMAT);
            }

            return user_month;
        }

        public int YearInput()
        {
            int user_year;

            try
            {
                user_year = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception(INPUT_IS_NOT_IN_RIGHT_FORMAT);
            }

            return user_year;
        }

        public decimal SumInput()
        {
            decimal user_sum;
            try
            {
                user_sum = Convert.ToDecimal(Console.ReadLine());
            }

            catch
            {
                throw new Exception(INPUT_IS_NOT_IN_RIGHT_FORMAT);
            }

            return user_sum;
        }

    }
}
