 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartmentsInTheStore>
        {
        
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_run : concern
        {
        
            It first_observation = () =>        
                
        }
    }
}
