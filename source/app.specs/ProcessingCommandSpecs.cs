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
        request = fake.an<IProvideDetailsForACommand>();
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_ = () =>
        

      static IProvideDetailsForACommand request;
      static bool result;
    }
  }
}
