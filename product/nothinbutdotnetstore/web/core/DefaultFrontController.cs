namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;

        public DefaultFrontController(CommandRegistry registry)
        {
            this.command_registry = registry;
        }

        public void process(Request request)
        {
            command_registry.get_command_that_can_process(request).run(request);
        }
    }
}