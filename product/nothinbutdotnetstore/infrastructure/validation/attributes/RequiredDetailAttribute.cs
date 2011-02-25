using System;

namespace nothinbutdotnetstore.infrastructure.validation.attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RequiredDetailAttribute : Attribute
    {
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