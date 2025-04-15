using Bussiness.Services.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductOrderManagementApı.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExampleController : ControllerBase
	{
		IExampleServices _exampleServices;
		ICustomerServices _customerServices;
        public ExampleController(IExampleServices exampleServices, ICustomerServices customerServices)
		{
			_exampleServices = exampleServices;
			_customerServices = customerServices;
		}
		[HttpGet("GetAllPriceList")]
		public async Task<List<Product>> GetAllPriceList()
		{
			var models = await _exampleServices.GetAllPriceList();
			return models;
		}
		[HttpGet("GetAllOrderList")]
		public async Task<List<Order>> GetAllOrderList()
		{
			var models = await _exampleServices.GetAllOrderList();
			return models;
		}
		[HttpGet("GetAllStock")]
		public async Task<List<Product>> GetAllStock()
		{
			var models = await _exampleServices.GetAllStock();
			return models;
		}
		[HttpPost("GetAllDate")]
		public async Task<List<Product>> GetAllDate([FromBody]DateTime dateTime)
		{
			var models = await _exampleServices.GetAllDate(dateTime);
			return models;
		}
	}
}
