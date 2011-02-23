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
    public class ViewDepartmentInADepartment : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine viewer;

        public ViewDepartmentInADepartment():this(Stub.with<StubDepartmentRepository>(),
            Stub.with<StubResponseEngine>())
        {
        }

        public ViewDepartmentInADepartment(DepartmentRepository department_repository, ResponseEngine viewer)
        {
            this.department_repository = department_repository;
            this.viewer = viewer;
        }

        public void run(Request request)
        {
            viewer.display(department_repository.get_the_sub_departments());
        }

    }
}
