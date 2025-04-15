using Bussiness.Services.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductOrderManagementApı.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IOrderServices _orderServices;

		public OrderController(IOrderServices orderServices)
		{
			_orderServices = orderServices;
		}
		[HttpGet("GetAllOrder")]
		public async Task<List<Order>> GetAllOrder()
		{
			var models = await _orderServices.GetAllOrder();
			return models;
		}
		[HttpGet("GetByIdOrder")]
		public async Task<Order> GetByIdOrder(int id)
		{
			var filter = await _orderServices.GetByIdOrder(id);
			return filter;
		}
		[HttpPost("AddOrder")]
		public async Task<Order> AddOrder(Order order)
		{
			var addModel = await _orderServices.AddOrder(order);
			return addModel;
		}
		[HttpGet("total")]
		public async Task<decimal> GetTotalOrderAmount()
		{
			var totalModel = await _orderServices.GetTotalOrderAmount();
			return totalModel;

		}
	}
}
