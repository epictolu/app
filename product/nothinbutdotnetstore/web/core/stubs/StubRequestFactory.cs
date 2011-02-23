using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext incoming_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
        }
    }
}