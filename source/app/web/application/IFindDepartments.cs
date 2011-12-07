using System.Collections.Generic;
using app.web.application.models;

namespace app.web.application
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_main_departments();
  }
}