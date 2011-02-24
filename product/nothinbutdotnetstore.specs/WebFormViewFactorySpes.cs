using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core.aspnet;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class WebFormViewFactorySpes
    {
        public abstract class concern : Observes<ViewFactory,
                                            WebFormViewFactory>
        {
        }

        [Subject(typeof(WebFormViewFactory))]
        public class when_creating_a_view_for_a_report_model : concern
        {
            Establish c = () =>
            {
                the_model = new TheModel();
                the_path = "blah.aspx";
                the_created_view = an<ViewFor<TheModel>>();
                view_path_registry = the_dependency<ViewPathRegistry>();

                view_path_registry.Stub(x => x.get_path_to_view_for<TheModel>())
                    .Return(the_path);

                provide_a_basic_sut_constructor_argument<PageFactory>((path, type) => (object) the_created_view);
            };

            Because b = () =>
                result = sut.create_view_for(the_model);

            It should_return_an_instance_of_the_view_with_its_model_populated = () =>
            {
                result.ShouldEqual(the_created_view);
                result.report_model.ShouldEqual(the_model);
            };

            static ViewFor<TheModel> result;
            static ViewFor<TheModel> the_created_view;
            static TheModel the_model;
            static ViewPathRegistry view_path_registry;
            static string the_path;
        }

        public class TheModel
        {
        }
    }
}