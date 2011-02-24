namespace nothinbutdotnetstore.infrastructure
{
    public interface Validator<ItemToValidate>
    {
        void validate(ItemToValidate item, Notifications notifications_to_populate);
    }
}