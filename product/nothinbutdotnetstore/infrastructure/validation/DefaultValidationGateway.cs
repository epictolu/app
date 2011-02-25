namespace nothinbutdotnetstore.infrastructure.validation
{
    public class DefaultValidationGateway : ValidationGateway
    {
        NotificationFactory notification_factory;
        RuleRegistry rule_registry;

        public DefaultValidationGateway(NotificationFactory notification_factory, RuleRegistry rule_registry)
        {
            this.notification_factory = notification_factory;
            this.rule_registry = rule_registry;
        }

        public Notifications validate<ItemToValidate>(ItemToValidate item)
        {
            var notifications = notification_factory.create_empty();
            foreach (var rule in rule_registry.all_rules_for<ItemToValidate>())
            {
                notifications.append(rule.apply_to(item));
            }
            return notifications;
        }
    }
}