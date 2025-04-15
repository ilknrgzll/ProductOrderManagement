
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFOrderDal : EFProductRepository<Order, Context>, IOrderDal
	{
		public EFOrderDal(Context context) : base(context)
		{
		}
	}
}
