 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class RequestCommandSpecs
    {
        public abstract class concern : utility.Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                criteria_return_value = DateTime.Now.Ticks % 2 ==0;
                provide_a_basic_sut_constructor_argument<RequestCriteria>(x => criteria_return_value);
            };

            Because b = () =>
                result = sut.can_handle(request);


            It should_make_the_determination_by_using_its_request_criteria = () =>
                result.ShouldEqual(criteria_return_value);

            static bool result;
            static Request request;
            static bool criteria_return_value;
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                application_command = the_sut_constructor_needs_a<ApplicationCommand>();
                the_sut_constructor_needs_a<RequestCriteria>(x => true);

                request = an<Request>();
            };

            Because b = () =>
                sut.run(request);


            It should_delegate_the_processing_to_the_application_functionality = () =>
                application_command.received(x => x.run(request));

            static Request request;
            static ApplicationCommand application_command;
        }
    }
}
