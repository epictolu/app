using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine viewer;

        public ViewMainDepartmentsInTheStore():this(new StubDepartmentRepository(),
            new StubResponseEngine())
        {
        }

        public ViewMainDepartmentsInTheStore(DepartmentRepository department_repository, ResponseEngine viewer)
        {
            this.department_repository = department_repository;
            this.viewer = viewer;
        }

        public void run(Request request)
        {
            viewer.display(department_repository.get_the_main_departments());
        }
    }
}