namespace MyApp.Domain.Entities
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public string? Nature { get; set; }

        public string? Signal { get; set; }

        public virtual ICollection<CustomerMovement>? CustomerMovement { get; set; }
    }
}
