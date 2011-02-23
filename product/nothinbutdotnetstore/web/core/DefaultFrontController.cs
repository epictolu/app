using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;
        RequestCommand request_command;

        public DefaultFrontController(CommandRegistry registry)
        {
            this.command_registry = registry;
        }

        public void process(Request request)
        {
            this.request_command = this.command_registry.get_command_that_can_process(request);
            this.request_command.run(request);
        }
    }
}