using System;

namespace nothinbutdotnetstore.infrastructure.validation.attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DateFallsInRangeAttribute : Attribute
    {
        DateTime start;
        DateTime end;
        public ItemProperty property_to_validate { get; set; }

        public DateFallsInRangeAttribute(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }

        public bool is_in_range(object item)
        {
            throw new NotImplementedException();
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IntegerFallsInRangeAttribute : Attribute
    {
        int start;
        int end;
        public ItemProperty property_to_validate { get; set; }

        public IntegerFallsInRangeAttribute(int start,int end)
        {
            this.start = start;
            this.end = end;
        }


        public bool is_in_range(object item)
        {
            int i = Convert.ToInt32((property_to_validate.get_value_from(item)));
            return ((i >= start) && (i <= end));
        }


    }
}