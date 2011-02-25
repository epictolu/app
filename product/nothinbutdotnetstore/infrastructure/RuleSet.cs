using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public interface RuleSet<ItemToCheck>
    {
        IEnumerable<Rule<ItemToCheck>> rules_broken_by(ItemToCheck item);
    }
}