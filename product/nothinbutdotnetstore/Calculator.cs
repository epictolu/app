using System;
using System.Data;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        public Calculator(IDbConnection connection)
        {
            open_database_connection(connection);
        }

        private void open_database_connection(IDbConnection connection)
        {
            connection.Open();
        }

        public int add(int first, int second)
        {
            ensure_all_numbers_are_positive(first, second);

            return first + second;
        }

        static void ensure_all_numbers_are_positive(int first, int second)
        {
            if(first < 0 || second < 0)
                throw new ArgumentException();
        }
    }
}
