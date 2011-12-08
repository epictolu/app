using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> all_commands;
    IProcessOneRequest the_missing_command;

    public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands, IProcessOneRequest the_missing_command)
    {
      this.all_commands = all_commands;
      this.the_missing_command = the_missing_command;
    }

    public CommandRegistry():this(Stub.with<StubSetOfCommands>(),Stub.with<StubMissingCommand>())
    {
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsForACommand request)

    {
      return all_commands.FirstOrDefault(x => x.can_handle(request)) ?? the_missing_command;
    }
  }
}