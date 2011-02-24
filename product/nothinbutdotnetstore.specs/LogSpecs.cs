using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class LogSpecs
    {
        public class concern : Observes<LoggingRequestFactory>
        {
            
        }

        public class When_logging_is_requested:concern
        {
            private Establish c = () =>
                                      {
                                          default_factory = the_dependency<RequestFactory>();
                                          log = the_dependency<Log>();
                                          incoming_request = ObjectFactory.Web.create_http_context();
                                          default_factory.Stub(x => x.create_request_from(incoming_request)).Return(
                                              resulting_request);

                                      };

            private Because b = () =>
                                    {
                                        sut.create_request_from(incoming_request);
                                    };

            private It should_log_a_message = () =>
                                                  {
                                                      log.received(x => x.message(resulting_request));
                                                  };

            private static RequestFactory default_factory;
            private static Request resulting_request;
            private static HttpContext incoming_request;
            private static Log log;

        }


    }
}
