using app.web.core;

namespace app.web.application
{
  public class ViewDepartmentsInADepartment : ISupportAStory
  {
    IFindDepartments department_repository;
    IDisplayReports display_engine;

    public ViewDepartmentsInADepartment(IFindDepartments department_repository, IDisplayReports display_engine)
    {
      this.department_repository = department_repository;
      this.display_engine = display_engine;
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(department_repository.get_departments_for_a_department(request));
    }
  }
}