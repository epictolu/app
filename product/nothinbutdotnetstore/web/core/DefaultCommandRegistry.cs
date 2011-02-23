using System;
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
            return this.commands.Where(c => c.can_handle(request)).FirstOrDefault();
        }
    }
}