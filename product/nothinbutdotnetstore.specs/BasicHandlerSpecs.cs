 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.aspnet;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class BasicHandlerSpecs
    {
        public abstract class concern : Machine.Specifications.DevelopWithPassion.Rhino.Observes<IHttpHandler,
                                            BasicHandler>
        {
        
        }

        [Subject(typeof(BasicHandler))]
        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = the_dependency<FrontController>();
                request_factory = the_dependency<RequestFactory>();

                request = an<Request>();
                incoming_context = ObjectFactory.create_http_context();

                request_factory.Stub(x => x.create_request_from(incoming_context))
                    .Return(request);

            };

            Because b = () =>
                sut.ProcessRequest(incoming_context);

            It should_delegate_the_processing_of_a_created_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(request));

            static FrontController front_controller;
            static Request request;
            static HttpContext incoming_context;
            static RequestFactory request_factory;
        }
    }
}
