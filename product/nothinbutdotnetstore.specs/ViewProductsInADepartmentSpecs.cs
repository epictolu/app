using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    public class ViewProductsInADepartmentSpec
    {
        public abstract class concern : utility.ItObserves<ApplicationCommand,
                                            ViewProductsInADepartment>
        {
        }

        [Subject(typeof(ViewProductsInADepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                response_engine = the_sut_constructor_needs_a<ResponseEngine>();
                store_catalog = the_sut_constructor_needs_a<StoreCatalog>();
                parent_department = new Department();

                request = an<Request>();
                request.Stub(x => x.map<Department>()).Return(parent_department);

                products = ObjectFactory.create_a_set_of(100, () => new Product());

                store_catalog.Stub(x => x.get_products_belonging_to(parent_department))
                    .Return(products);
            };

            Because b = () =>
                sut.run(request);

            It should_display_the_list_of_products = () =>
                response_engine.received(x => x.display(products));

            static StoreCatalog store_catalog;
            static Request request;
            static IEnumerable<Product> products;
            static ResponseEngine response_engine;
            static Department parent_department;
        }
    }
}