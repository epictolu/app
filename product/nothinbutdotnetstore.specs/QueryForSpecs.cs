using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class QueryForSpecs
    {
        public abstract class concern : ItObserves<ApplicationCommand,
                                            QueryFor<IEnumerable<SomeReportModel>>>
        {
        }

        [Subject(typeof(QueryFor<IEnumerable<SomeReportModel>>))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                response_engine = the_sut_constructor_needs_a<ResponseEngine>();
                items = ObjectFactory.create_a_set_of(100, () => new SomeReportModel());
                the_sut_constructor_needs_a<ItemQuery<IEnumerable<SomeReportModel>>>(x => items);
                request = an<Request>();
            };

            Because b = () =>
                sut.run(request);

            It should_display_the_item_found_by_the_query = () =>
                response_engine.received(x => x.display(items));

            static Request request;
            static IEnumerable<SomeReportModel> items;
            static ResponseEngine response_engine;
        }

        public class SomeReportModel
        {
        }
    }
}