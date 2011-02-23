using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : utility.Observes<ApplicationCommand,
                                            ViewMainDepartmentsInTheStore>
        {
        
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                response_engine = the_sut_constructor_needs_a<ResponseEngine>();
                department_repository = the_sut_constructor_needs_a<DepartmentRepository>();
                request = an<Request>();

                main_departments = ObjectFactory.create_a_set_of(100, () => new Department());


                department_repository.Stub(x => x.get_the_main_departments())
                    .Return(main_departments);

            };

            Because b = () =>
                sut.run(request);

            It should_display_the_list_of_main_departments = () =>
                response_engine.received(x => x.display(main_departments));


  


            static DepartmentRepository department_repository;
            static Request request;
            static IEnumerable<Department> main_departments;
            static ResponseEngine response_engine;
        }
    }
}
