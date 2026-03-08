using System.Collections.Concurrent;
using OrderFlow.Application.Interfaces;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private static readonly ConcurrentDictionary<Guid, Order> _orders = new(); // Using ConcurrentDictionary because it supports multiple threads safely
        public Task<Order?> GetByIdAsync(Guid id)
        {
            _orders.TryGetValue(id, out var order);
            return Task.FromResult(order);
        }

        public Task UpdateAsync(Order order)
        {
            _orders[order.Id] = order;
            return Task.CompletedTask;
        }

        public Task AddAsync(Order order)
        {
            _orders[order.Id] = order;
            return Task.CompletedTask;
        }
    }
}