using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : ApplicationCommand
    {
        StoreCatalog store_catalog;
        ResponseEngine viewer;


        public ViewProductsInADepartment(StoreCatalog store_catalog, ResponseEngine viewer)
        {
            this.store_catalog = store_catalog;
            this.viewer = viewer;
        }

        public void run(Request request)
        {
            viewer.display(store_catalog.get_products_belonging_to(request.map<Department>()));
        }
    }
}