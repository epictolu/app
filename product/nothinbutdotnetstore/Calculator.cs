using System;
using System.Data;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        private IDbConnection dbConnection;

        public Calculator(IDbConnection connection)
        {
            dbConnection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_numbers_are_positive(first, second);

            dbConnection.Open();

            return first + second;
        }

        static void ensure_all_numbers_are_positive(int first, int second)
        {
            if(first < 0 || second < 0)
                throw new ArgumentException();
        }
    }
}
