using MyApp.Domain.Entities;

namespace MyApp.Services.Interfaces
{
    public interface ICustomerMovementService
    {
        Task<CustomerMovement> LineToCustomerMovement(string line);
    }
}
