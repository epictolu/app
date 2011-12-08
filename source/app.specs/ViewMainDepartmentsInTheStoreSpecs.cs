 using System.Collections.Generic;
using app.web.application;
 using app.web.application.models;
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
        display_engine = depends.on<IDisplayReports>();
        department_repository = depends.on<IFindDepartments>();
        request = fake.an<IProvideDetailsForACommand>();
        the_main_departments = new List<DepartmentItem> {new DepartmentItem()};

        department_repository.setup(x => x.get_main_departments())
          .Return(the_main_departments);
      };

      Because b = () =>
        sut.run(request);

      It should_display_the_list_of_the_main_departments = () =>
        display_engine.display(the_main_departments);

      static IFindDepartments department_repository;
      static IProvideDetailsForACommand request;
      static IEnumerable<DepartmentItem> the_main_departments;
      static IDisplayReports display_engine;
    }
  }

  [Subject(typeof(ViewDepartmentsInADepartment))]
  public class ViewDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewDepartmentsInADepartment>
    {

    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsForACommand>();
        department_repository = depends.on<IFindDepartments>();
        display_engine = depends.on<IDisplayReports>();

        request.department = department;

        department_repository.setup(x => x.get_departments_for_a_department(department)).Return(departments_for_the_department);
      };

      Because of = () =>
        sut.run(request);

      It should_display_the_departments_for_the_department = () =>
        display_engine.received(x => x.display(departments_for_the_department));

      static IFindDepartments department_repository;
      static IProvideDetailsForACommand request;
      static IDisplayReports display_engine;
      static IEnumerable<DepartmentItem> departments_for_the_department;
      static DepartmentItem department;
    }
  }
}
