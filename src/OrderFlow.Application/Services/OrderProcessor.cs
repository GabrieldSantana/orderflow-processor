using OrderFlow.Application.Interfaces;
using OrderFlow.Domain.Enums;

namespace OrderFlow.Application.Services
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderRepository _repository;

        public OrderProcessor(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcessAsync(Guid orderId)
        {
            var order = await _repository.GetByIdAsync(orderId);

            if(order is null)
                throw new Exception("Order not found.");

            if(order.Status != OrderStatus.Pending)
                return;
            
            order.MarkAsProcessing();

            await Task.Delay(500); 

            order.MarkAsCompleted();

            await _repository.UpdateAsync(order);
        }
    }
}