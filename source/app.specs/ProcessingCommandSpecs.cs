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
          expected = true;
          request = fake.an<IProvideDetailsForACommand>();
          request.setup(x => x.CanBeHandledBy(sut)).Return(expected);
      };

      Because b = () =>
        result = sut.can_handle(request);

        It should_correctly_determine_if_it_can_handle_the_request = () => result.ShouldEqual(expected);
        

      static IProvideDetailsForACommand request;
      static bool result;
      static bool expected;
    }
  }
}
