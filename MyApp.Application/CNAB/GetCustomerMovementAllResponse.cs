using MyApp.Domain.Entities;

namespace MyApp.Application.CNAB
{
    public class GetCustomerMovementAllResponse
    {
        public IEnumerable<CustomerMovement>? CustomerMovements { get; set; }
    }
}
