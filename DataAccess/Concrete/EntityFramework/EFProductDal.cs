using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;


namespace DataAccess.Concrete.EntityFramework
{
	public class EFProductDal : EFProductRepository<Product, Context>, IProductDal
	{
		public EFProductDal(Context context) : base(context)
		{
		}
	}
}
