
using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductOrderManagementApı.Middlewares;

namespace ProductOrderManagementApı
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<Context>((serviceProvider, options) =>
			{
				var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
				options.UseSqlServer(connectionString).EnableDetailedErrors().EnableSensitiveDataLogging();
			});
			
			// API'yi yapılandırma
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddAuthorization();
			builder.Services.AddControllers();
			builder.Services.AddSwaggerGen();

			// Servisleri ve Data Access katmanlarını DI container'a ekleyin
			builder.Services.AddScoped<IOrderServices, OrderManager>();
			builder.Services.AddScoped<IProductServices, ProductManager>();
			builder.Services.AddScoped<ICustomerServices, CustomerManager>();
			builder.Services.AddScoped<IExampleServices, ExampleManager>();

			builder.Services.AddScoped<IOrderDal, EFOrderDal>();
			builder.Services.AddScoped<ICustomerDal, EFCustomerDal>();
			builder.Services.AddScoped<IProductDal, EFProductDal>();
			
			// Cors ayarları
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader();
				});
			});

			builder.Services.AddHttpContextAccessor();
			builder.Logging.AddConsole();


			var app = builder.Build();

			// Geliştirme ortamında Swagger ve SwaggerUI'yi aktif etme
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			// Middleware konfigürasyonları
			app.UseMiddleware<LogMiddleware>();

			app.UseCors("AllowAll");
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			// Authorization middleware'ı ekleyin (bu yorum satırına alınmış)
			// app.UseAuthorization();
			Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

			app.Run();

		}
	}
}



