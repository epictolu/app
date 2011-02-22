using System;

namespace nothinbutdotnetstore
{
    public class Calculator
    {
        public static int add(int first, int second)
        {
            if(first < 0 || second < 0)
                throw new ArgumentException();

            return first + second;
        }
    }
}