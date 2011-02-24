namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultValidator<ItemToValidate> : Validator<ItemToValidate>
    {
        RuleSet<ItemToValidate> rule_set;

        public DefaultValidator(RuleSet<ItemToValidate> rule_set)
        {
            this.rule_set = rule_set;
        }

        public void validate(ItemToValidate item, Notifications notifications_to_populate)
        {
            if (rule_set.is_broken_by(item))
            {
                foreach (string notification in rule_set.all_messages())
                {
                    notifications_to_populate.add_error(notification);
                }
            }
        }
    }
}