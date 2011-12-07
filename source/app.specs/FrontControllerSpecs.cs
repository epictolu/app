 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests,
                                      FrontController>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsForACommand>();
        command_that_can_process_request = fake.an<IProcessOneRequest>();
        command_registry = depends.on<IFindCommands>();

        command_registry.setup(x => x.get_the_command_that_can_process(request)).Return(command_that_can_process_request);
      };

      Because b = () =>
        sut.process(request);


      It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
        command_that_can_process_request.received(x => x.run(request));

      static IProcessOneRequest command_that_can_process_request;
      static IProvideDetailsForACommand request;
      static IFindCommands command_registry;
    }
  }
}
