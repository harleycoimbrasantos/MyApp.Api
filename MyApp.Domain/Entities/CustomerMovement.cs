namespace MyApp.Domain.Entities
{
    public class CustomerMovement
    {
        public Guid Id { get; set; }

        public DateTime? MovementDate { get; set; }

        public decimal? Value { get; set; }

        public string? Document { get; set; }

        public string? CardNumber { get; set;}

        public string? MovementTime { get; set; }

        public string? StoreOwnerName { get; set; }

        public string? StoreName { get; set; }

        public int TransactionTypeId { get; set; }

        public virtual TransactionType? TransactionType { get; set; }
    }
}

