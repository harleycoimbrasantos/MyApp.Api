using MyApp.Data.Context;
using MyApp.Data.Interface;
using MyApp.Domain.Entities;

namespace MyApp.Data.Repository
{
    public class CustomerMovementRepository : Repository<CustomerMovement>, ICustomerMovementRepository
    {
        public CustomerMovementRepository(SQLContext context) : base(context)
        {
        }
    }
}
