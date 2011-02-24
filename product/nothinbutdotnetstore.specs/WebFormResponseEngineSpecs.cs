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

            It first_observation = () =>
            {

            };
                
        }
    }
}
