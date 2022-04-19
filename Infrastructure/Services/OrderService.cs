using Core;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Infrastructure.Services
{
	public class OrderService : IOrderService
	{
		private readonly IGenericRepository<Order> _orderRepository;
		private readonly IFileService _fileService;	

		public OrderService(IGenericRepository<Order> orderRepository, IFileService fileService)
		{
			_orderRepository = orderRepository;
			_fileService = fileService;
		}

		public Task<bool> CreateOrder(OrderFullInfo orderInfo)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> CreateUserOrder(int userId, OrderFullInfo orderInfo)
		{
			var order = GetOrderFromOrderFullInfo(orderInfo);
			order.CustomerId = userId;

			for (int i = 0; i < orderInfo.Files.Count; i++)
			{
				order.RelatedData.Files.Add(new UploadedFile
				{
					Url = await _fileService.AddFileAsync(orderInfo.Files[i])
				}); 
			}

			await _orderRepository.AddEntityAsync(order);
			return true;
		}

		public void UpdateOrder(int orderId, OrderFullInfo orderInfo)
		{
			throw new NotImplementedException();
		}

		private Order GetOrderFromOrderFullInfo(OrderFullInfo orderFull)
		{
			var order = new Order
			{
				CustomerName = orderFull.CustomerName,
				CustomerNumber = orderFull.CustomerNumber,
				CustomerEmail = orderFull.CustomerEmail,
				Price = orderFull.Price,
				OrderObjectDetails = new OrderObjectDetails
				{
					ObjectAddres = orderFull.ObjectAddres,
					CleaningType = (CleaningType)orderFull.CleaningType,
					CleaningArea = orderFull.CleaningArea,
					CleaningDate = orderFull.CleaningDate
				},
				OrderDescription = new OrderDescription
				{
					Status = OrderStatus.WaitManagerConfirm,
					IsApprovedOrder = false
				},
				RelatedData = new UserMessage
				{
					Comment = orderFull.Comment,
					Files = new List<UploadedFile>(orderFull.Files.Count)
				},
				CleaningTasks = new List<CleaningTask>(orderFull.Tasks.Count)
			};
			for (int i = 0; i < orderFull.Tasks.Count; i++)
				order.CleaningTasks.Add(new CleaningTask()
				{
					IsDone = false,
					TaskDescription = orderFull.Tasks[i]
				});
			return order;
		}
	}
}
