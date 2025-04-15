using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
	public interface ICustomerServices
	{
		Task<List<Customer>> GetAllCustomer();
		Task<Customer> AddCustomer(Customer customer);
	}
}
