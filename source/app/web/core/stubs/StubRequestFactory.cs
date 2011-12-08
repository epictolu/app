using System.Web;
using app.web.application.models;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IProvideDetailsForACommand create_request_from(HttpContext context)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsForACommand
    {
      public DepartmentItem department { get; set; }
    }
  }
}