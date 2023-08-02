using MyApp.Data.Context;
using MyApp.Domain.Entities;
using MyApp.Services.Interfaces;

namespace MyApp.Services.Service
{
    public class CustomerMovementService : ICustomerMovementService
    {
        private readonly SQLContext _context;

        public CustomerMovementService(SQLContext context)
        {
            _context = context;
        }

        public async Task<CustomerMovement> LineToCustomerMovement(string line)
        {
            var transactionTypeId = int.Parse(line.Substring(0, 1));

            bool debit =
                _context.TransactionTypes.Where(t => t.Id.Equals(transactionTypeId)).FirstOrDefault().Signal.Equals("-");

            var year = int.Parse(line.Substring(1, 4));
            var month = int.Parse(line.Substring(5, 2));
            var day = int.Parse(line.Substring(7, 2));
            var dateMovement = new DateTime(year, month, day);
            var value = decimal.Parse(line.Substring(10, 10));
            var time = $@"{line.Substring(42, 2)}:{line.Substring(44, 2)}:{line.Substring(46, 2)}";

            var customerMovement = new CustomerMovement()
            {
                Id = Guid.NewGuid(),
                TransactionTypeId = transactionTypeId,
                MovementDate = dateMovement,
                Value = !debit ? value / 100 : (value/100)*-1,
                Document = line.Substring(20, 11),
                CardNumber = line.Substring(31, 11),
                MovementTime = time,
                StoreOwnerName = line.Substring(48, 14),
                StoreName = line.Substring(62, 18)
            };

            return customerMovement;
        }
    }
}
