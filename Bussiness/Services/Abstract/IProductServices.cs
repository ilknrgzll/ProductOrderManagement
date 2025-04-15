using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
	public interface IProductServices
	{
		Task<List<Product>> GetAllProduct();
		Task<Product>GetByIdAsync(int id);
		Task<Product> AddProduct(Product product);
		Task<bool> UpdateProduct(int id);
		Task<bool> DeleteProduct(int id);
	}
}
