using System.Web;
using nothinbutdotnetstore.web.application;

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
            public InputModel map<InputModel>()
            {
                object item = new Department();
                return (InputModel) item;
            }
        }
    }
}