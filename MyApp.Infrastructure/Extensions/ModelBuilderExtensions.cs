using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SeedDataTransactionType(this ModelBuilder builder)
        {
            builder.Entity<TransactionType>()
                .HasData(
                    new TransactionType { Id = 1, Description = "Débito", Nature = "Entrada", Signal = "+" },
                    new TransactionType { Id = 2, Description = "Boleto", Nature = "Saída", Signal = "-" },
                    new TransactionType { Id = 3, Description = "Financiamento", Nature = "Saída", Signal = "-" },
                    new TransactionType { Id = 4, Description = "Crédito", Nature = "Entrada", Signal = "+" },
                    new TransactionType { Id = 5, Description = "Recebimento Empréstimo", Nature = "Entrada", Signal = "+" },
                    new TransactionType { Id = 6, Description = "Vendas", Nature = "Entrada", Signal = "+" },
                    new TransactionType { Id = 7, Description = "Recebimento TED", Nature = "Entrada", Signal = "+" },
                    new TransactionType { Id = 8, Description = "Recebimento DOC", Nature = "Entrada", Signal = "+" },
                    new TransactionType { Id = 9, Description = "Aluguel", Nature = "Saída", Signal = "-" }
                );

            return builder;
        }
    }
}
