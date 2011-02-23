using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public class StoreCatalogController
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> get_products_belonging_to(Department parent_department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> get_departments_belonging_to(Department parent_department)
        {
            throw new NotImplementedException();
        }

    }
}