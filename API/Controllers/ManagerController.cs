using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManagerController : ControllerBase
	{
		private readonly IGenericRepository<Order> _orderRepos;
		private readonly IMapper _mapper;

		public ManagerController(IGenericRepository<Order> orderRepos, IMapper mapper)
		{
			_orderRepos = orderRepos;
			_mapper = mapper;
		}

		[HttpGet("orders")]
		public async Task<ActionResult<Pagination<OrderShortInfo>>> GetOrders([FromQuery] OrderSpecParams orderParams)
		{
			var spec = new ManagerOrdersWithSmallAdditionalInfo(orderParams);

			var totalOrders = await _orderRepos.CountAllAsync();

			var orders = await _orderRepos.ListAsync(spec);

			var returnData = _mapper
				.Map<IReadOnlyList<Order>, IReadOnlyList<OrderShortInfo>>(orders);

			return Ok(new Pagination<OrderShortInfo>
				(orderParams.PageIndex, orderParams.PageSize, totalOrders, returnData));
		}
	}
}
