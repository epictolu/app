using app.web.application.stubs;
using app.web.core;

namespace app.web.application
{
  public class ViewMainDepartmentsInTheStore : ISupportAStory
  {
    IFindStoreInformation store_catalog;
    IDisplayReports display_engine;

    public ViewMainDepartmentsInTheStore(IFindStoreInformation store_catalog, IDisplayReports display_engine)
    {
      this.store_catalog = store_catalog;
      this.display_engine = display_engine;
    }

    public ViewMainDepartmentsInTheStore():this(Stub.with<StubStoreCatalog>(),Stub.with<StubDisplayEngine>())
    {
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(store_catalog.get_main_departments());
    }
  }
}