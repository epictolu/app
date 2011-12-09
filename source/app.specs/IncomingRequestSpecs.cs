using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (IncomingRequest))]
    public class IncomingRequestSpecs
    {
        public abstract class concern : Observes
        {
        }


        public class incoming_request : concern
        {
            Establish c = () =>
                              {
                                  result_match_builder = fake.an<IBuildRequestMatches>();
                                  RequestResolver result_match_builder_delegate = () => result_match_builder;
                                  spec.change(() => IncomingRequest.request_match_resolver).to(result_match_builder_delegate);
                              };

            Because b = () => result = IncomingRequest.was;

            It should_return_a_default_request_builder = () => result.ShouldEqual(result_match_builder);

            static IBuildRequestMatches result;
            static IBuildRequestMatches result_match_builder;
        }
    }
}