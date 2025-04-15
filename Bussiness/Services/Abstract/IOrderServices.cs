using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
	public interface IOrderServices
	{
		Task<Order> AddOrder(Order order);
		Task<Order> GetByIdOrder(int id);
		Task<List<Order>> GetAllOrder();
		Task<decimal> GetTotalOrderAmount();
	}
}
