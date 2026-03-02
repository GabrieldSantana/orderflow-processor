using OrderFlow.Domain.Entities;

namespace OrderFlow.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task UpdateAsync(Order order);
    }
}