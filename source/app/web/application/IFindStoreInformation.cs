using System.Collections.Generic;
using app.web.application.models;

namespace app.web.application
{
  public interface IFindStoreInformation 
  {
    IEnumerable<DepartmentItem> get_main_departments();
    IEnumerable<DepartmentItem> get_departments_for_a_department(ViewSubDepartmentsRequest request);
    IEnumerable<ProductItem> all_products_in(ViewProductsRequest departmentItem);
  }
}