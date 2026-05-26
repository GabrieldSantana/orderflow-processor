namespace OrderFlow.Application.Events
{
    public class OrderCreatedEvent
    {
        public Guid OrderId { get; set; } // Identify order
        public string? CostumerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } // Traceability
    } 
}