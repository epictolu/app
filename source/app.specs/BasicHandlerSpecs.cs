 using System.Web;
 using Machine.Fakes;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(BasicHandler))]  
  public class BasicHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      BasicHandler>
    {
        
    }

   
    public class when_processing_an_http_context : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateControllerRequests>();
        controller_request = fake.an<IProvideDetailsForACommand>();
        context = ObjectFactory.web.create_http_context();

        request_factory.setup(x => x.create_request_from(context)).Return(controller_request);
      };

      Because b = () =>
        sut.ProcessRequest(context);

      It should_delegate_the_processing_of_a_new_controller_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(controller_request));

      static IProcessRequests front_controller;
      static IProvideDetailsForACommand controller_request;
      static HttpContext context;
      static ICreateControllerRequests request_factory;
    }
  }
}
