namespace nothinbutdotnetstore.infrastructure
{
    public interface Rule<Item>
    {
        Notifications apply_to(Item item);
    }
}