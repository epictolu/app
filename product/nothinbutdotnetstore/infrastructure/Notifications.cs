namespace nothinbutdotnetstore.infrastructure
{
    public interface Notifications
    {
        bool contains_errors();
        void add_error(string message);
    }
}