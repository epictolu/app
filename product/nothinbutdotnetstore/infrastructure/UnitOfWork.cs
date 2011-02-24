using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.infrastructure
{
    public interface UnitOfWork
    {
        void save<ItemToSave>(ItemToSave item);
    }
}