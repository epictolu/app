using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return new DefaultRequestCommand(x => true,
              new ViewDepartmentInADepartment());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}