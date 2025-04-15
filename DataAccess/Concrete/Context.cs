using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
	public class Context : DbContext
	{
		//private readonly IConfiguration _configuration;
        public Context()
        {
            
        }
        // Parametresiz yapıcı ekle
        public Context(DbContextOptions<Context> options) : base(options) { }

		//public Context(IConfiguration configuration)
		//{
		//	_configuration = configuration;
		//}

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Customer> Customers { get; set; }
		

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
			
		//}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.Property(p => p.Price)
				.HasColumnType("decimal(18,2)"); // 18 basamak, 2 ondalık haneli
		}
		
	}


}
