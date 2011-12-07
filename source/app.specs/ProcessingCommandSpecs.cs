 using System;
 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ProcessingCommand))]  
  public class ProcessingCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      ProcessingCommand>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {

      Establish c = () =>
      {
        var type = depends.on(typeof(string));
        request = fake.an<IProvideDetailsForACommand>();
        request.setup(x => x.GetType()).Return(type);
      };

      Because b = () =>
        result = sut.can_handle(request);

        It should_correctly_determine_if_it_can_handle_the_request = () => result.ShouldBeTrue();
        

      static IProvideDetailsForACommand request;
      static bool result;
    }
  }
}
