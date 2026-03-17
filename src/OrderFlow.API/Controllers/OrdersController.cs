using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.Contracts;
using OrderFlow.Application.Interfaces;
using OrderFlow.Domain.Entities;

namespace OrderFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderProcessor _processor;
        private readonly IOrderRepository _repository;

        public OrdersController(IOrderProcessor processor, IOrderRepository repository)
        {
            _processor = processor;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var order = new Order(request.CostumerEmail, request.TotalAmount);
            await _repository.AddAsync(order);
            
            return Ok(order.Id);
        }

        [HttpPost("{id}/process")]
        public async Task<IActionResult> Process(Guid id)
        {
            await _processor.ProcessAsync(id);

            return Ok();
        }
    }
}