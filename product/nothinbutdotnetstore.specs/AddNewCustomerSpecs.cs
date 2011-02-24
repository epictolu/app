 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class AddNewCustomerSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            AddNewCustomer>
        {
        
        }

        [Subject(typeof(AddNewCustomer))]
        public class when_run : concern
        {
            Establish c = () =>
            {
                customer_tasks = the_dependency<CustomerTasks>();
                customer = new Customer();
                request = an<Request>();

                request.Stub(x => x.map<Customer>())
                    .Return(customer);

            };
            Because b = () =>
                sut.run(request);

            It should_add_a_new_customer_to_the_system = () =>
                customer_tasks.received(x => x.save(customer));

            static CustomerTasks customer_tasks;
            static Customer customer;
            static Request request;
        }
    }
}
