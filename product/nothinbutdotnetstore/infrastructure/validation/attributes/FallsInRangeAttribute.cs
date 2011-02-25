using System;

namespace nothinbutdotnetstore.infrastructure.validation.attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FallsInRangeAttribute : Attribute
    {
        int start;
        int end;

        public FallsInRangeAttribute(int start,int end)
        {
            this.start = start;
            this.end = end;
        }
    }
}