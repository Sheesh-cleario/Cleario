using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class UserOrdersWithFiltersForCountSpecification : BaseSpecification<Order>
	{
		public UserOrdersWithFiltersForCountSpecification(UserOrderSpecParams orderParams) : base
			(x => x.CustomerId == orderParams.UserId)
		{
		}
	}
}
