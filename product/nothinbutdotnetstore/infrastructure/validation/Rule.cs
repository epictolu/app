namespace nothinbutdotnetstore.infrastructure.validation
{
    public interface Rule<Item>
    {
        Notifications apply_to(Item item);
    }
}