using System.Collections;
using System.Collections.Generic;
using app.web.application;

namespace app.web.core.stubs
{
  public class StubSetOfCommands:IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new ProcessingCommand(x => true,
                                         new ViewDepartmentsInADepartment());
//      yield return new ProcessingCommand(x => true,
//                                         new ViewMainDepartmentsInTheStore());

    }
  }
}