using System.Collections;
using System.Collections.Generic;
using app.web.application;
using app.web.application.models;
using app.web.application.stubs;

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
                                         new ViewReport<IEnumerable<ProductItem>,GetTheProductsInADepartment>());
      yield return new ProcessingCommand(x => true,
                                         new ViewReport<IEnumerable<DepartmentItem>,GetMainDepartments>());
      yield return new ProcessingCommand(x => true,
                                         new ViewReport<IEnumerable<DepartmentItem>,GetDepartmentsInDepartment>());

    }
  }

  public class GetDepartmentsInDepartment:IFetchInformation<IEnumerable<DepartmentItem>>
  {
    public IEnumerable<DepartmentItem> fetch_using(IProvideDetailsForACommand request)
    {
      return Stub.with<StubStoreCatalog>().get_departments_for_a_department(request.map<DepartmentItem>());
    }
  }

  public class GetMainDepartments : IFetchInformation<IEnumerable<DepartmentItem>>
  {
    public IEnumerable<DepartmentItem> fetch_using(IProvideDetailsForACommand request)
    {
      return Stub.with<StubStoreCatalog>().get_main_departments();
    }
  }
  public class GetTheProductsInADepartment : IFetchInformation<IEnumerable<ProductItem>>
  {
    public IEnumerable<ProductItem> fetch_using(IProvideDetailsForACommand request)
    {
      return Stub.with<StubStoreCatalog>().all_products_in(request.map<DepartmentItem>());
    }
  }
}