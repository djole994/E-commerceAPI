using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly EcommerceContext _context;

        public OrderController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Izračunaj ukupni iznos iz stavki
            decimal total = model.Items.Sum(i => i.Price * i.Quantity);

            var order = new Order
            {
                // Ne postavljamo CustomerId, jer je guest checkout
                CustomerName = model.CustomerName,
                Address = model.Address,
                PaymentMethod = model.PaymentMethod,
                TotalAmount = total,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in model.Items)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                };
                _context.OrderItems.Add(orderItem);
            }
            await _context.SaveChangesAsync();

            return Ok(new { success = true, orderId = order.Id });
        }



        public class OrderRequestModel
        {
            [Required]
            [JsonPropertyName("customerName")]
            public string CustomerName { get; set; }

            [Required]
            [JsonPropertyName("address")]
            public string Address { get; set; }

            [Required]
            [JsonPropertyName("paymentMethod")]
            public string PaymentMethod { get; set; }

            [Required]
            [JsonPropertyName("items")]
            public List<OrderItemRequest> Items { get; set; }
        }

        public class OrderItemRequest
        {
            [JsonPropertyName("productId")]
            public int ProductId { get; set; }

            [JsonPropertyName("price")]
            public decimal Price { get; set; }

            [JsonPropertyName("quantity")]
            public int Quantity { get; set; }
        }

    }
}