using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class WebFormResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            WebFormResponseEngine>
        {
        }

        [Subject(typeof(WebFormResponseEngine))]
        public class when_displaying_a_report_model : concern
        {
            Establish c = () =>
            {
                view = an<ViewFor<OurModelToDisplay>>();
                model = new OurModelToDisplay();
                factory = the_dependency<ViewFactory>();
                current_context = ObjectFactory.Web.create_http_context();

                factory.Stub(x => x.create_view_for(model))
                    .Return(view);

                provide_a_basic_sut_constructor_argument<CurrentContextResolver>(() => current_context);


            };

            Because b = () =>
                sut.display(model);


            It should_tell_the_view_that_can_display_the_information_to_run_in_the_current_context = () =>
                view.received(x => x.ProcessRequest(current_context));
  


            static OurModelToDisplay model;
            static ViewFactory factory;
            static ViewFor<OurModelToDisplay> view;
            static HttpContext current_context;
        }

        public class OurModelToDisplay
        {
        }
    }
}