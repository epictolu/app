using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection,IDataReader data_reader)
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

        public void shut_off()
        {
            ensure_is_in_correct_role();
        }

        void ensure_is_in_correct_role()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) return;

            throw new SecurityException();
        }
    }
}
