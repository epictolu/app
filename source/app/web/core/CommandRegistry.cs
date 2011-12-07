using System;
using System.Collections.Generic;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
      public IEnumerable<IProcessOneRequest> allCommands ;
      public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands)
      {
           allCommands = all_commands;
      }

      public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsForACommand request)
       
    {
          foreach (var command in allCommands)
          {
              if (command.can_handle(request))
                  return command;
          }
          throw new NotImplementedException();
    }
  }
}