using System;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.validation;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultCustomerTasks : CustomerTasks
    {
        ValidationGateway validation_gateway;
        UnitOfWork unit_of_work;

        public DefaultCustomerTasks(ValidationGateway validation_gateway, UnitOfWork unit_of_work)
        {
            this.validation_gateway = validation_gateway;
            this.unit_of_work = unit_of_work;
        }

        public Notifications save(Customer customer)
        {
            var notifications = validation_gateway.validate(customer);
            if (! notifications.contains_errors()) unit_of_work.save(customer);
            return notifications;
        }
    }
}