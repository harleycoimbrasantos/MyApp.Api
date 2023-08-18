using MyApp.Domain.Entities;

namespace MyApp.Data.Interface
{
    public interface ICustomerMovementRepository : IRepository<CustomerMovement>
    {
        IEnumerable<CustomerMovement> GetAll();
    }
}
