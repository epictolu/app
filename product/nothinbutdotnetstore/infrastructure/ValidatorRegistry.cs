using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public interface ValidatorRegistry
    {
        IEnumerable<Rule<Item>> all_rules_for<Item>();
    }
}