using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentRepository
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Main Department 0")});
        }
        public IEnumerable<Department> get_departments_belonging_to(Department parent_department)
        {
            return Enumerable.Range(1, 100).Select(x => new Department { name = x.ToString("Sub Department 0") });
        }
    }
}