using System;

namespace nothinbutdotnetstore.model
{
    public class Customer
    {
        public string name { get; set; }
        public DateTime birth_day { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public int age { get; set; }
    }
}