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
    public class ViewDepartmentInADepartmentSpecs
    {
        public abstract class concern : utility.Observes<ApplicationCommand,
                                            ViewDepartmentInADepartment>
        {

        }

        [Subject(typeof(ViewDepartmentInADepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                response_engine = the_sut_constructor_needs_a<ResponseEngine>();
                department_repository = the_sut_constructor_needs_a<DepartmentRepository>();
                parent_department = new Department();

                request = an<Request>();
                request.Stub(x => x.map<Department>()).Return(parent_department);


                sub_departments = ObjectFactory.create_a_set_of(100, () => new Department());

                department_repository.Stub(x => x.get_departments_belonging_to(parent_department))
                    .Return(sub_departments);

            };

            Because b = () =>
                sut.run(request);

            It should_display_the_list_of_sub_departments = () =>
                response_engine.received(x => x.display(sub_departments));





            static DepartmentRepository department_repository;
            static Request request;
            static IEnumerable<Department> sub_departments;
            static ResponseEngine response_engine;
            static Department parent_department;
        }
    }
}
