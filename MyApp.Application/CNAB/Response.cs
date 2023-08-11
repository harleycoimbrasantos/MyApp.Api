namespace MyApp.Application.CNAB
{
    public class Response
    {
        public bool Success { get; set; }
        public IEnumerable<SummaryResponse>? Summaries { get; set; }
    }

    public class SummaryResponse
    {
        public string? Store { get; set; }
        public decimal? Total { get; set; }
        public IEnumerable<MovementResponse>? Movements { get; set; }
    }

    public class MovementResponse
    {
        public DateTime? MovementDate { get; set; }

        public decimal? Value { get; set; }

        public string? Document { get; set; }

        public string? CardNumber { get; set; }

        public string? MovementTime { get; set; }

        public string? StoreName { get; set; }

        public int? TransactionTypeId { get; set; }

        public string? TransactionTypeDescription { get; set; }
    }
}
