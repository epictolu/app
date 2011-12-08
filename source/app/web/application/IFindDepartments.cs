using System.Collections.Generic;
using app.web.application.models;

namespace app.web.application
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_main_departments();
    IEnumerable<DepartmentItem> get_departments_for_a_department(DepartmentItem item);
  }
}