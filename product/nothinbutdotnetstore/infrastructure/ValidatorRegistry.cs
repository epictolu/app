namespace nothinbutdotnetstore.infrastructure
{
    public interface ValidatorRegistry
    {
        Validator<ItemToValidate> get_validator_for<ItemToValidate>();
    }
}