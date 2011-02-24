using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CustomerTasks
    {
        Notifications save(Customer customer);
    }
}