using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
	public interface IExampleServices
	{
		Task<List<Product>> GetAllPriceList();

		Task<List<Order>> GetAllOrderList();
		Task<List<Product>> GetAllStock();
		Task<List<Product>> GetAllDate(DateTime dateTime);
	}
}
