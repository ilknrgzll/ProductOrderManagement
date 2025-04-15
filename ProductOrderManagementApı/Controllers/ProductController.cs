using Bussiness.Services.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductOrderManagementApı.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
			_productServices = productServices;
        }
		[HttpGet("GetAllProduct")]
		public async Task<List<Product>> GetAllProduct()
		{
			var models = await _productServices.GetAllProduct();
			return models;
		}
		[HttpGet("GetByIdProduct")]
		public async Task<Product> GetByIdAsync(int id)
		{
			var filter = await _productServices.GetByIdAsync(id);
			return filter;
		}
		[HttpPost("AddProduct")]
		public async Task<Product> AddProduct(Product product)
		{
			var addModel = await _productServices.AddProduct(product);
			return addModel;
		}
		[HttpPut("UpdateProduct")]
		public async Task<bool> UpdateProduct(int id)
		{
			var addModel = await _productServices.UpdateProduct(id);
			return addModel;
		}
		[HttpDelete("DeleteProduct")]
		public async Task<bool> DeleteProduct(int id)
		{
			var addModel = await _productServices.DeleteProduct(id);
			return addModel;
		}
	}
}
