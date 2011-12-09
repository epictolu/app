using System;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (RequestMatchBuilder))]
    public class RequestMatchBuilderSpecs
    {
        public abstract class concern : Observes<IBuildRequestMatches, RequestMatchBuilder>{}

        public class when_a_request_match_is_built_for_a_certain_type : concern
        {
            Establish c = () => 
            {
                good_request = new GoodRequest();
                bad_request = fake.an<IProvideDetailsForACommand>();
            };

            Because b = () => result = sut.made_for<GoodRequest>();

            It should_be_able_to_handle_a_request_of_its_type = () => result.Invoke(good_request).ShouldBeTrue();

            It should_not_be_able_to_handle_a_request_of_another_type = () => result.Invoke(bad_request).ShouldBeFalse();

            static RequestMatch result;
            static IProvideDetailsForACommand good_request;
            static IProvideDetailsForACommand bad_request;
        }

        public class GoodRequest : IProvideDetailsForACommand
        {
            public InputModel map<InputModel>()
            {
                throw new NotImplementedException();
            }
        }

        public class MyInputModel
        {
        }
    }
}
