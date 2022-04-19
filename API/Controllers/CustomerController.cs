using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IGenericRepository<Customer> _customerRepos;
		private readonly IGenericRepository<Order> _orderRepos;
		private readonly IMapper _mapper;

		public CustomerController(IGenericRepository<Customer> customerRepos, IGenericRepository<Order> orderRepos, IMapper mapper)
		{
			_customerRepos = customerRepos;
			_orderRepos = orderRepos;
			_mapper = mapper;
		}

		[HttpGet("user")]
		public async Task<ActionResult<Customer>> GetDefaultCustomer()
		{
			var user = await _customerRepos.GetByIdAsync(1);
			if (user == null)
				return BadRequest();
			return user;
		}


		[HttpGet("orders")]
		public async Task<ActionResult<Pagination<OrderShortInfo>>> GetOrders([FromQuery] UserOrderSpecParams orderParams)
		{
			var spec = new UserOrdersWithSmallAdditionalInfo(orderParams);

			var countSpec = new UserOrdersWithFiltersForCountSpecification(orderParams);

			var totalOrders = await _orderRepos.CountAsync(countSpec);

			var orders = await _orderRepos.ListAsync(spec);

			var returnData = _mapper
				.Map<IReadOnlyList<Order>, IReadOnlyList<OrderShortInfo>>(orders);

			return Ok(new Pagination<OrderShortInfo>
				(orderParams.PageIndex, orderParams.PageSize, totalOrders, returnData));
		}

	}
}
