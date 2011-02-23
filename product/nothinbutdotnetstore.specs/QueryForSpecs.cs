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
    public class QueryForSpecs
    {
        public abstract class concern : utility.Observes<ApplicationCommand,
                                            QueryFor<IEnumerable<Department>>>
        {
        }

        [Subject(typeof(ViewDepartmentInADepartment))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                response_engine = the_sut_constructor_needs_a<ResponseEngine>();
                parent_department = new Department();
                the_sut_constructor_needs_a<ItemQuery<IEnumerable<Department>>>(x => sub_departments);

                request = an<Request>();
                request.Stub(x => x.map<Department>()).Return(parent_department);

                sub_departments = ObjectFactory.create_a_set_of(100, () => new Department());

            };

            Because b = () =>
                sut.run(request);

            It should_display_the_item_found_by_the_query = () =>
                response_engine.received(x => x.display(sub_departments));

            static Request request;
            static IEnumerable<Department> sub_departments;
            static ResponseEngine response_engine;
            static Department parent_department;
        }
    }
}