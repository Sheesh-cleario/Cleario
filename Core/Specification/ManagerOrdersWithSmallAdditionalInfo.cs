using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
	public class ManagerOrdersWithSmallAdditionalInfo: BaseSpecification<Order>
	{
		public ManagerOrdersWithSmallAdditionalInfo(OrderSpecParams orderParams) : base()
		{
			AddInclude(x => x.OrderDescription);
			AddInclude(x => x.OrderObjectDetails);
			ApplyPaging(orderParams.PageSize * (orderParams.PageIndex - 1), orderParams.PageSize);
		}
	}
}
