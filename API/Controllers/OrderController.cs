using API.DTOs;
using Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;	
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("price")]
		public int GetOrderPrice([FromBody] OrderObjectDetails orderDetails, [FromServices] IOrderPriceService priceService)
		{
			return priceService.CalculateOrderPrice(orderDetails);
		}

		[HttpPost("createOrder/{role}")]
		public async Task CreateOrder(string role, [FromQuery] int userId, [FromForm] OrderFullInfo orderInfo)
		{

		}
	}
}
