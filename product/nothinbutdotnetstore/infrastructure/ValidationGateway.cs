namespace nothinbutdotnetstore.infrastructure
{
    public interface ValidationGateway
    {
        Notifications validate<ItemToValidate>(ItemToValidate item);
    }
}