using System;

namespace nothinbutdotnetstore.infrastructure.validation.attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FallsInRangeAttribute : Attribute
    {
        int start;
        int end;
        public ItemProperty property_to_validate { get; set; }

        public FallsInRangeAttribute(int start,int end)
        {
            this.start = start;
            this.end = end;
        }


        public bool is_in_range(object item)
        {
            int i = Convert.ToInt32((property_to_validate.get_value_from(item)));
            return ((i >= start) && (i <= end));
        }

        /*
         public ItemProperty property_to_validate { get; set; }

        public bool is_valid(object item)
        {
            var value = property_to_validate.get_value_from(item);

            return value != null && is_non_empty_string(value);
        }

        bool is_non_empty_string(object item)
        {
            if (item is string)
            {
                return ! string.IsNullOrEmpty(item.ToString());
            }

            return true;
        }
         */

    }
}