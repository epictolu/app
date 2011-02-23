using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_the_main_departments();
        IEnumerable<Department> get_departments_belonging_to(Department parent_department);
    }
}