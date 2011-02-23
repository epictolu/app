 using System;
 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class CommandRegistrySpecs
    {
        public abstract class concern : Machine.Specifications.DevelopWithPassion.Rhino.Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
        
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_finding_a_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();

                all_commands = new List<RequestCommand>();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);

                the_command_that_can_process_the_request = an<RequestCommand>();

                Enumerable.Range(1,100).each(x => all_commands .Add(an<RequestCommand>()));
                all_commands.Add(the_command_that_can_process_the_request);


                the_command_that_can_process_the_request.Stub(x => x.can_handle(request))
                    .Return(true);

            };
            Because b = () =>
                result = sut.get_command_that_can_process(request);



            It should_return_the_command_that_can_handle_the_request = () =>
                result.ShouldEqual(the_command_that_can_process_the_request);

            static RequestCommand result;
            static RequestCommand the_command_that_can_process_the_request;
            static Request request;
            static List<RequestCommand> all_commands;
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_attempting_to_find_a_command_that_can_process_a_request_and_there_is_no_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();

                provide_a_basic_sut_constructor_argument(ObjectFactory
                    .create_a_set_of(100,an<RequestCommand>));

            };
            Because b = () =>
                result = sut.get_command_that_can_process(request);



            It should_return_a_missing_command_to_the_caller = () =>
                result.ShouldBeAn<MissingRequestCommand>();

            static RequestCommand result;
            static Request request;
        }
    }
}
