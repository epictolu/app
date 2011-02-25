using System;
using nothinbutdotnetstore.infrastructure.validation.attributes;

namespace nothinbutdotnetstore.model
{
    public class Customer
    {
        [RequiredDetail]
        public string name { get; set; }

        [RequiredDetail]
        public DateTime birth_day { get; set; }

        public string address { get; set; }
        public string state { get; set; }

        [IntegerFallsInRange(18,50)]
        public int age { get; set; }
    }
}