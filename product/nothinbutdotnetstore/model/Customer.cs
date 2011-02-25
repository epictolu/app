using System;
using nothinbutdotnetstore.infrastructure.validation.attributes;

namespace nothinbutdotnetstore.model
{
    public class Customer
    {
        [RequiredDetail]
        public string name { get; set; }

        [RequiredDetail]
        [BornAfter(1977)]
        public DateTime birth_day { get; set; }

        public string address { get; set; }
        public string state { get; set; }
        public int age { get; set; }
    }
}