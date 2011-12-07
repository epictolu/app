using app.web.application.stubs;
using app.web.core;

namespace app.web.application
{
  public class ViewMainDepartmentsInTheStore : ISupportAStory
  {
    IFindDepartments department_repository;
    IDisplayReports display_engine;

    public ViewMainDepartmentsInTheStore(IFindDepartments department_repository, IDisplayReports display_engine)
    {
      this.department_repository = department_repository;
      this.display_engine = display_engine;
    }

    public ViewMainDepartmentsInTheStore():this(new StubDepartmentRepository(),new StubDisplayEngine())
    {
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(department_repository.get_main_departments());
    }
  }
}