using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.validation
{
    public interface RuleRegistry
    {
        IEnumerable<Rule<Item>> all_rules_for<Item>();
    }
}