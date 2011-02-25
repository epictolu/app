 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.infrastructure.validation;
 using nothinbutdotnetstore.model;
 using nothinbutdotnetstore.tasks;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{   
    public class CustomerTasksSpecs
    {
        public abstract class concern : Observes<CustomerTasks,
                                            DefaultCustomerTasks>
        {
        
        }

        [Subject(typeof(DefaultCustomerTasks))]
        public class when_saving_a_customer_and_the_information_is_invalid : concern
        {
            Establish c = () =>
            {
                unit_of_work = the_dependency<UnitOfWork>();
                validation_gateway = the_dependency<ValidationGateway>();
                errors = an<Notifications>();
                customer = new Customer();

                errors.Stub(x => x.contains_errors()).Return(true);

                validation_gateway.Stub(x => x.validate(customer))
                    .Return(errors);
            };

            Because b = () =>
                result = sut.save(customer);


            It should_return_a_set_of_validation_errors_to_the_client = () =>
                result.ShouldEqual(errors);

            It should_not_save_the_customer_information = () =>
                unit_of_work.never_received(x => x.save(customer));

  

            static Notifications result;
            static Notifications errors;
            static Customer customer;
            static UnitOfWork unit_of_work;
            static ValidationGateway validation_gateway;
        }
    }
}
