using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry():this(Stub.with<StubSetOfCommands>())
        {
        }

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.commands = all_commands;
        }

        public RequestCommand get_command_that_can_process(Request request)
        {
            return commands.FirstOrDefault(command => command.can_handle(request))
                ?? new MissingRequestCommand();
        }
    }
}