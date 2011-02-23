using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;

using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;
using Machine.Specifications;

namespace nothinbutdotnetstore.specs
{
    public class ViewProductsInADepartmentSpec
    {
        public abstract class concern : utility.Observes<ApplicationCommand,
                                            ViewProductsInADepartment>
        {

        }

        [Subject(typeof(ViewProductsInADepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                response_engine = the_sut_constructor_needs_a<ResponseEngine>();
                product_repository = the_sut_constructor_needs_a<ProductRepository>();
                parent_department = new Department();

                request = an<Request>();
                request.Stub(x => x.map<Department>()).Return(parent_department);


                products = ObjectFactory.create_a_set_of(100, () => new Product());

                product_repository.Stub(x => x.get_products_belonging_to(parent_department))
                    .Return(products);

            };

            Because b = () =>
                sut.run(request);

            It should_display_the_list_of_products = () =>
                response_engine.received(x => x.display(products));

            static ProductRepository product_repository;
            static Request request;
            static IEnumerable<Product> products;
            static ResponseEngine response_engine;
            static Department parent_department;
        }
    }
}
