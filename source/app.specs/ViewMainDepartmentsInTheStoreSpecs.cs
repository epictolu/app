using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.models;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

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
        store_information_repository = depends.on<IFindStoreInformation>();
        request = fake.an<IProvideDetailsForACommand>();
        the_main_departments = new List<DepartmentItem> {new DepartmentItem()};

        store_information_repository.setup(x => x.get_main_departments())
          .Return(the_main_departments);
      };

      Because b = () =>
        sut.run(request);

      It should_display_the_list_of_the_main_departments = () =>
        display_engine.display(the_main_departments);

      static IFindStoreInformation store_information_repository;
      static IProvideDetailsForACommand request;
      static IEnumerable<DepartmentItem> the_main_departments;
      static IDisplayReports display_engine;
    }
  }
}