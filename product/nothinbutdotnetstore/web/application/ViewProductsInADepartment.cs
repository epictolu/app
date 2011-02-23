using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : ApplicationCommand
    {
        ProductRepository product_repository;
        ResponseEngine viewer;

        public ViewProductsInADepartment():this(Stub.with<StubProductRepository>(),
            Stub.with<StubResponseEngine>())
        {
        }

        public ViewProductsInADepartment(ProductRepository product_repository, ResponseEngine viewer)
        {
            this.product_repository = product_repository;
            this.viewer = viewer;
        }

        public void run(Request request)
        {
            viewer.display(product_repository.get_products_belonging_to(request.map<Department>()));
        }

    }
}
