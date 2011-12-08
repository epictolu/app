using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.models;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
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
        store_information_repository = depends.on<IFindStoreInformation>();
        department = new DepartmentItem();
        departments_for_the_department = new List<DepartmentItem>
        {new DepartmentItem()};
        display_engine = depends.on<IDisplayReports>();

        request.setup(x => x.map<DepartmentItem>()).Return(department);

        store_information_repository.setup(
          x => x.get_departments_for_a_department(department)).Return(
            departments_for_the_department);
      };

      Because of = () =>
        sut.run(request);

      It should_display_the_departments_for_the_department =
        () => display_engine.received(x => x.display(departments_for_the_department));

      static IFindStoreInformation store_information_repository;
      static IProvideDetailsForACommand request;
      static IDisplayReports display_engine;
      static IEnumerable<DepartmentItem> departments_for_the_department;
      static DepartmentItem department;
    }
  }
}