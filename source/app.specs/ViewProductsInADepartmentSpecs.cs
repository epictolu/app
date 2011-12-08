using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.models;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;


namespace app.specs
{
    [Subject(typeof(ViewProductsInADepartment))]
    public class ViewProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ISupportAStory,ViewProductsInADepartment>
        {
        }

        public class when_run : concern
        {

            private static IDisplayReports display_engine;
            private static IProvideDetailsForACommand request;
            private static ProductItem product_item;

            Establish c = () =>
                              {
                                  request = fake.an<IProvideDetailsForACommand>();
                                  request.setup(x => x.map<DepartmentItem>()).Return(department_Item);

                                  var productRepository = depends.on<IFindProducts>();
                                  productRepository.setup(x => x.GetProductList(department_Item)).Return(product_list);

                                  display_engine = depends.on<IDisplayReports>();
                              };

            Because of = () => sut.run(request);


            It should_display_the_products_for_the_department = () =>
                display_engine.received(x => x.display(product_list));

            private static DepartmentItem department_Item;
            private static IEnumerable<ProductItem> product_list;
        }}
}