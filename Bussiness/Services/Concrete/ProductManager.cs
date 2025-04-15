using Bussiness.Services.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Bussiness.Services.Concrete
{
	public class ProductManager : IProductServices
	{
		private Context _context;
		private IProductDal _productDal;
		public ProductManager(Context context, IProductDal productDal)
		{
			_context = context;
			_productDal = productDal;
		}

		public async Task<Product> AddProduct(Product product)
		{
			var maptoProduct = new Product
			{
				Id = product.Id,
				Name = product.Name,
				CreatedAt = DateTime.Now,
				Price = product.Price,
				Stock = product.Stock,

			};
			var result =await _productDal.AddAsync(maptoProduct);
			return result;
		}
		public async Task<List<Product>> GetAllProduct()
		{
			var products = await _productDal.GetAllAsync();
			var mapToProducts = products.Select(x => new Product
			{
				Id = x.Id,
				CreatedAt = x.CreatedAt,
				Name = x.Name,
				Price = x.Price,
				Stock = x.Stock,
				UpdatedAt = x.UpdatedAt,

			}).ToList();

			return mapToProducts;
		}
		public async Task<Product> GetByIdAsync(int id)
		{
			var products = await _productDal.GetByIdAsync(p => p.Id == id);

			if (products == null)
			{
				throw new Exception($" Böyle bir ürün bulunmadı: {id}");
			}
			return products;

			
		}

		public async Task<bool> UpdateProduct(int id)
		{
			var products = await _productDal.GetAllAsync(p => p.Id == id);
			var product = products.FirstOrDefault(); 
			if (product == null)
			{
				return false;
			}

			product.UpdatedAt = DateTime.Now;

			var result = await _productDal.UpdateAsync(product);

			return result;
		}

		public async Task<bool> DeleteProduct(int id)
		{
			var product = await _productDal.GetByIdAsync(p => p.Id == id);

			if (product == null)
			{
				return false;
			}

			var result = await _productDal.DeleteAsync(product);

			return result; 
		}

	}
}

