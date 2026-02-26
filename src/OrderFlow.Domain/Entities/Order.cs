using OrderFlow.Domain.Enums;

namespace OrderFlow.Domain.Entities
{
public class Order
{
    public Guid Id { get; private set; }
    public string CustomerEmail { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }

    public Order(string costumerEmail, decimal totalAmount)
    {
        Id = Guid.NewGuid();
        CustomerEmail = costumerEmail;
        TotalAmount = totalAmount;
        CreatedAt = DateTime.UtcNow;
        Status = OrderStatus.Pending;
    }

    public void MarkAsProcessing()
        => Status = OrderStatus.Processing;

    public void MarkAsCompleted()
        => Status = OrderStatus.Completed;

    public void MarkAsFailed()
        => Status = OrderStatus.Failed;   

}
}