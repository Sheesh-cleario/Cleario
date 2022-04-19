using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IOrderService
	{
		Task<bool> CreateOrder(OrderFullInfo orderInfo);
		Task<bool> CreateUserOrder(int userId, OrderFullInfo orderInfo);

		void UpdateOrder(int orderId, OrderFullInfo orderInfo);

	}
}
