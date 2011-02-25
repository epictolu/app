namespace nothinbutdotnetstore.infrastructure
{
    public interface Notifications
    {
        bool contains_errors();
        void append(Notifications notification);
    }
}