namespace nothinbutdotnetstore.web.core
{
    public interface RequestCommand
    {
        bool can_handle(Request request);
        void run(Request request);

    }
}