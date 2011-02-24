using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class LoggingRequestFactory:RequestFactory
    {
        private readonly RequestFactory _factory;
        private readonly Log _logger;

        public LoggingRequestFactory(RequestFactory factory, Log logger)
        {
            _factory = factory;
            _logger = logger;
        }

        public Request create_request_from(System.Web.HttpContext incoming_context)
        {
            Request request = _factory.create_request_from(incoming_context);
            _logger.message(request);
            return request;
        }
    }
}
