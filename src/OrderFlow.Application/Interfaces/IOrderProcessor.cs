namespace OrderFlow.Application.Interfaces
{
    public interface IOrderProcessor
    {
        Task ProcessAsync(Guid orderId);
    }
}