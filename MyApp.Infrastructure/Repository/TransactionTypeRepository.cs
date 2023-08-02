using MyApp.Data.Context;
using MyApp.Data.Interface;
using MyApp.Domain.Entities;

namespace MyApp.Data.Repository
{
    public class TransactionTypeRepository : Repository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(SQLContext context) : base(context)
        {
        }
    }
}
