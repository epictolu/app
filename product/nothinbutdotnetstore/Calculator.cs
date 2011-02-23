using System;
using System.Data;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_numbers_are_positive(first, second);

            using (connection)
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            return first + second;
        }

        static void ensure_all_numbers_are_positive(int first, int second)
        {
            if(first < 0 || second < 0)
                throw new ArgumentException();
        }
    }
}
