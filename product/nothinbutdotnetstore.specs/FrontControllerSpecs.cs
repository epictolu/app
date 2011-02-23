using Machine.Specifications;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;
using RhinoMocksExtensions = Machine.Specifications.DevelopWithPassion.Rhino.RhinoMocksExtensions;

namespace nothinbutdotnetstore.specs
{
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = the_sut_constructor_needs_a<CommandRegistry>();

                request = an<Request>();
                command_that_can_run_request = an<RequestCommand>();

                command_registry.Stub(x => x.get_command_that_can_process(request))
                    .Return(command_that_can_run_request);
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_the_command_that_can_run_the_request = () =>
                RhinoMocksExtensions.received(command_that_can_run_request, x => x.run(request));

            static RequestCommand command_that_can_run_request;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}