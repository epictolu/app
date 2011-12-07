using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    public IEnumerable<IProcessOneRequest> all_commands;

    public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands)
    {
      this.all_commands = all_commands;
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsForACommand request)

    {
      return all_commands.First(x => x.can_handle(request));
    }
  }
}