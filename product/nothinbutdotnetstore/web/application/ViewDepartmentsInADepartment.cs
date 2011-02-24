using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentInADepartment : ApplicationCommand
    {
        StoreCatalog store_catalog;
        ResponseEngine viewer;


        public ViewDepartmentInADepartment(StoreCatalog store_catalog, ResponseEngine viewer)
        {
            this.store_catalog = store_catalog;
            this.viewer = viewer;
        }

        public void run(Request request)
        {
            viewer.display(store_catalog.get_departments_belonging_to(request.map<Department>()));
        }
    }
}