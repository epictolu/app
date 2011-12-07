using System.Collections.Generic;
using System.Linq;
using app.web.application.models;

namespace app.web.application.stubs
{
  public class StubDepartmentRepository:IFindDepartments
  {
    public IEnumerable<DepartmentItem> get_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem{name = x.ToString("Department 0")});
    }
  }
}