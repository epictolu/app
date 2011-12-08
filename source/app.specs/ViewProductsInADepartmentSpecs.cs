using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.models;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewProductsInADepartment))]
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      static IDisplayReports display_engine;
      static IProvideDetailsForACommand request;
      static ProductItem product_item;

      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        var product_repository = depends.on<IFindStoreInformation>();
        department_item = fake.an<DepartmentItem>();

        request = fake.an<IProvideDetailsForACommand>();
        request.setup(x => x.map<DepartmentItem>()).Return(department_item);
        product_list = new List<ProductItem> {new ProductItem()};

        product_repository.setup(x => x.all_products_in(department_item)).Return(product_list);
      };

      Because of = () => sut.run(request);

      It should_display_the_products_for_the_department = () =>
        display_engine.received(x => x.display(product_list));

      static DepartmentItem department_item;
      static IEnumerable<ProductItem> product_list;
    }
  }
}