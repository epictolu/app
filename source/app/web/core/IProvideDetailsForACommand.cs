using app.web.application.models;

namespace app.web.core
{
  public interface IProvideDetailsForACommand
  {
    DepartmentItem department { get; set; }
  }
}