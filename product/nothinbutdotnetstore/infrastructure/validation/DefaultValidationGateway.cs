namespace nothinbutdotnetstore.infrastructure.validation
{
    public class DefaultValidationGateway : ValidationGateway
    {
        NotificationsFactory notifications_factory;
        RuleRegistry rule_registry;

        public DefaultValidationGateway(NotificationsFactory notifications_factory, RuleRegistry rule_registry)
        {
            this.notifications_factory = notifications_factory;
            this.rule_registry = rule_registry;
        }

        public Notifications validate<ItemToValidate>(ItemToValidate item)
        {
            var notifications = notifications_factory.create_empty();
            foreach (var rule in rule_registry.all_rules_for<ItemToValidate>())
            {
                notifications.append(rule.apply_to(item));
            }
            return notifications;
        }
    }
}