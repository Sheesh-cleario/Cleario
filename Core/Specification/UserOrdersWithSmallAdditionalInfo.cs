using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class UserOrdersWithSmallAdditionalInfo : BaseSpecification<Order>
	{
		public UserOrdersWithSmallAdditionalInfo(UserOrderSpecParams orderParams) : base
			(x => x.CustomerId == orderParams.UserId)
		{
			AddInclude(x => x.OrderDescription);
			AddInclude(x => x.OrderObjectDetails);
			ApplyPaging(orderParams.PageSize * (orderParams.PageIndex - 1), orderParams.PageSize);
		}

	}
}
