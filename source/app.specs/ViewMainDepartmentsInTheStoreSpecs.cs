 using System.Collections.Generic;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

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
      Establish c = () =>
      {
        department_list = depends.on<IFindDepartments>();
        request = fake.an<IProvideDetailsForACommand>();
      };

      Because b = () =>
        sut.run(request);

      It should_get_the_list_of_the_main_departments = () =>
        department_list.received(x => x.get_main_departments());

      static IFindDepartments department_list;
      static IProvideDetailsForACommand request;
    }
  }

  public interface IFindDepartments
  {
    IEnumerable<IContainDepartmentInformation> get_main_departments();
  }

  public interface IContainDepartmentInformation
  {
  }
}
