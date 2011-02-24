namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultValidationGateway : ValidationGateway
    {
        NotificationFactory notification_factory;
        ValidatorRegistry validator_registry;

        public DefaultValidationGateway(NotificationFactory notification_factory, ValidatorRegistry validator_registry)
        {
            this.notification_factory = notification_factory;
            this.validator_registry = validator_registry;
        }

        public Notifications validate<ItemToValidate>(ItemToValidate item)
        {
            var notifications = notification_factory.create_empty();
            validator_registry.get_validator_for<ItemToValidate>().validate(item, notifications);
            return notifications;
        }
    }
}