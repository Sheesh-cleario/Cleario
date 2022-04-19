using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class OrderPriceService : IOrderPriceService
	{
		public int CalculateOrderPrice(OrderObjectDetails orderDetails)
		{
			return Random.Shared.Next(100);
		}
	}
}
