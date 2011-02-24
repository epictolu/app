using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure
{
    public interface RuleSet<ItemToCheck>
    {
        bool is_broken_by(ItemToCheck item);
        IEnumerable<string> all_messages();
    }
}