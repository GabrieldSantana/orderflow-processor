using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.Contracts;
using OrderFlow.Application.Events;
using OrderFlow.Application.Interfaces;
using OrderFlow.Domain.Entities;
using OrderFlow.Infrastructure.Messaging;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderProcessor _processor;
        private readonly IOrderRepository _repository;
        private readonly RabbitMqPublisher _publisher;

        public OrdersController(IOrderProcessor processor, IOrderRepository repository, RabbitMqPublisher publisher)
        {
            _processor = processor;
            _repository = repository;
            _publisher = publisher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var order = new Order(request.CostumerEmail, request.TotalAmount);
            await _repository.AddAsync(order);

            // Creates the event
            var orderEvent = new OrderCreatedEvent
            {
                OrderId = order.Id,
                CostumerEmail = order.CustomerEmail,
                TotalAmount = order.TotalAmount,
                CreatedAt = DateTime.UtcNow
            };

            // Publishes the event to RabbitMQ
            await _publisher.Publish("order-created", orderEvent);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id = order.Id },
                order
                );
        }

        [HttpPost("{id}/process")]
        public async Task<IActionResult> Process(Guid id)
        {
            await _processor.ProcessAsync(id);

            return Ok();
        }
    }
}