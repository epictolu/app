using System.Collections.Generic;
using System.Linq;
using app.web.application.models;

namespace app.web.application.stubs
{
  public class StubStoreCatalog : IFindStoreInformation
  {
    public IEnumerable<DepartmentItem> get_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_departments_for_a_department(DepartmentItem item)
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem {name = x.ToString("Sub Department 0")});
    }

    public IEnumerable<ProductItem> all_products_in(DepartmentItem departmentItem)
    {
      return Enumerable.Range(1, 100).Select(x => new ProductItem {name = x.ToString("Product 0")});
    }
  }
}