using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.commands = all_commands;
        }

        public RequestCommand get_command_that_can_process(Request request)
        {
            RequestCommand rc = commands.Where(command => command.can_handle(request)).FirstOrDefault();

            if (rc == null)
                rc = new MissingRequestCommand();

            return rc;
        }
    }
}