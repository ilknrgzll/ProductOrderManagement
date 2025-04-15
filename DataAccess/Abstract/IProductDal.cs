using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IProductDal : IProductRepository<Product>
	{
	}
}
