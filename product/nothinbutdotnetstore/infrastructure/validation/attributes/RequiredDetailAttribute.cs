using System;

namespace nothinbutdotnetstore.infrastructure.validation.attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RequiredDetailAttribute : Attribute
    {
        
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class BornAfterAttribute : Attribute
    {
        int year;

        public BornAfterAttribute(int year)
        {
            this.year = year;
        }
    }
}