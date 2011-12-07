 using Machine.Specifications;
 using app.web.application;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ViewMainDepartmentsInTheStore))]  
  public class ViewMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewMainDepartmentsInTheStore>
    {
        
    }

   
    public class when_run : concern
    {
      It should_get_the_list_of_the_main_departments = () =>        


        
    }
  }
}
