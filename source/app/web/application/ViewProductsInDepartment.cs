using app.web.application.models;
using app.web.application.stubs;
using app.web.core;

namespace app.web.application
{
  public class ViewProductsInADepartment : ISupportAStory

  {
    IFindStoreInformation store_catalog;
    IDisplayReports display_engine;

    public ViewProductsInADepartment(IFindStoreInformation store_catalog, IDisplayReports displayEngine)
    {
      this.store_catalog = store_catalog;
      display_engine = displayEngine;
    }

    public ViewProductsInADepartment() : this(Stub.with<StubStoreCatalog>(), Stub.with<StubDisplayEngine>())
    {
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(store_catalog.all_products_in(request.map<DepartmentItem>()));
    }
  }
}