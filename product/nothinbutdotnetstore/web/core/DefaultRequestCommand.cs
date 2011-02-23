namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria criteria;
        ApplicationCommand application_command;

        public DefaultRequestCommand(RequestCriteria criteria, ApplicationCommand application_command)
        {
            this.criteria = criteria;
            this.application_command = application_command;
        }

        public void run(Request request)
        {
            application_command.run(request);
        }

        public bool can_handle(Request request)
        {
            return criteria(request);
        }
    }
}