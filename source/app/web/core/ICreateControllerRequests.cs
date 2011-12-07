using System.Web;

namespace app.web.core
{
  public interface ICreateControllerRequests
  {
    IProvideDetailsForACommand create_request_from(HttpContext context);
  }
}