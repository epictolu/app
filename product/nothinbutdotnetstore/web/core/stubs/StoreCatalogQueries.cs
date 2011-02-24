using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StoreCatalogQueries
    {
        StoreCatalog catalog;

        public StoreCatalogQueries() : this(new StubStoreCatalog())
        {
        }

        public StoreCatalogQueries(StoreCatalog catalog)
        {
            this.catalog = catalog;
        }

        public IEnumerable<Department> get_main_departments(Request request)
        {
            return new StubStoreCatalog().get_the_main_departments();
        }

        public IEnumerable<Product> get_products_belonging_to_department(Request request)
        {
            return catalog.get_products_belonging_to(request.map<Department>());
        }

        public IEnumerable<Department> get_departments_belonging_to_department(Request request)
        {
            return catalog.get_departments_belonging_to(request.map<Department>());
        }
    }
}