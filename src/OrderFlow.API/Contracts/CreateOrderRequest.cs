namespace OrderFlow.API.Contracts
{
    public class CreateOrderRequest
    {
        public string CostumerEmail { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}