using Bussiness.Services.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
	public class CustomerManager:ICustomerServices
	{
		private Context _context;
		private ICustomerDal _customerDal;
		public CustomerManager(Context context, ICustomerDal customerDal)
		{
			_context = context;
			_customerDal = customerDal;
		}
		public async Task<Customer> AddCustomer(Customer customer)
		{
			var maptoCustomer = new Customer
			{
				Id = customer.Id,
				Name = customer.Name,
				CreatedAt = DateTime.Now,
				Email= customer.Email,

			};
			var result = await _customerDal.AddAsync(maptoCustomer);
			return result;
		}
		public async Task<List<Customer>> GetAllCustomer()
		{
			var products = await _customerDal.GetAllAsync();
			var mapToProducts = products.Select(x => new Customer
			{
				Id=x.Id,
				Name = x.Name,
				CreatedAt= DateTime.Now,
				Email = x.Email,
				
			}).ToList();

			return mapToProducts;
		}

	}
}
