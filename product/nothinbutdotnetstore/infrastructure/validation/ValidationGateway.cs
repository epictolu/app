namespace nothinbutdotnetstore.infrastructure.validation
{
    public interface ValidationGateway
    {
        Notifications validate<ItemToValidate>(ItemToValidate item);
    }
}