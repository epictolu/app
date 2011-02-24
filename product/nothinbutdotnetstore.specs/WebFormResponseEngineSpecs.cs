 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.core.aspnet;

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
            private Establish c = () =>
                                      {
                                          model = an<object>();
                                          locator = the_dependency<ViewLocator>();
                                          response= new WebFormResponseEngine(locator);
                                          //pass in a ViewLocator
                                      };

            private Because b = () =>
                                    {
                                        response.display(model);
                                    };


            It should_locate_the_matching_view = () =>
            {
                //call to a view locator
            };

            It should_save_the_context_for_the_view = () =>
                                                                  {
                //this may be hard to test
                //call to ViewContext.Save
                                                                  };

            private It should_request_the_view_to_render_itself = () =>
                                                                      {
                //call to view.render()
                                                                      };

            private static ResponseEngine response;
            private static object model;
            private static ViewLocator locator;
        }

    }
}
