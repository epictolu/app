using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class AddNewCustomer : ApplicationCommand
    {
        CustomerTasks tasks;

        public AddNewCustomer(CustomerTasks tasks)
        {
            this.tasks = tasks;
        }

        public void run(Request request)
        {
            tasks.save(request.map<Customer>());
        }
    }
}