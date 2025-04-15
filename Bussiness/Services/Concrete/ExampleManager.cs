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
	public class ExampleManager : IExampleServices
	{
		private Context _context;
		private IOrderDal _orderDal;
		private IProductDal _productDal;
		public ExampleManager(Context context, IOrderDal orderDal, IProductDal productDal)
		{
			_context = context;
			_orderDal = orderDal;
			_productDal = productDal;
		}
		public async Task<List<Product>> GetAllPriceList()
		{
			var expensiveProducts = await _productDal.GetAllAsync(x=>x.Price>500);
			var mapToList = expensiveProducts.Select(x => new Product
			{
				Id = x.Id,
				Name = x.Name,				

			}).ToList();

			return mapToList;

		}
		public async Task<List<Order>> GetAllOrderList()
		{
			var orders=await _orderDal.GetAllAsync();
			var products = await _productDal.GetAllAsync();

			var mostOrderedProduct = orders
			.GroupBy(o => o.ProductId) // Siparişleri ProductId'ye göre gruplama
			.Select(g => new
			{
				ProductId = g.Key,
				TotalQuantity = g.Sum(o => o.Quantity) // Toplam sipariş miktarını hesaplama
			})
			.OrderByDescending(p => p.TotalQuantity) // Sipariş miktarına göre azalan sırada sıralama
			.Join(products, // Ürün bilgilerini eklemek için products ile birleştir
				o => o.ProductId,
				p => p.Id,
				(o, p) => new
				{
					p.Name,
					o.TotalQuantity
				})
			.FirstOrDefault(); // En çok sipariş edilen ürünü seçme

			// Sonucu yazdırma
			return orders;
		}
		public async Task<List<Product>> GetAllStock()
		{
			var products=await _productDal.GetAllAsync();
			int totalStock = products.Sum(p => p.Stock);
			return new List<Product>(totalStock);
		}
		public async Task<List<Product>> GetAllDate(DateTime dateTime)
		{
			var orders = await _orderDal.GetAllAsync(); // Siparişleri al
			var products = await _productDal.GetAllAsync(); // Ürünleri al

			// Belirtilen tarihten sonra sipariş edilen ürünlerin ID'lerini al
			var productIds = orders
				.Where(o => o.OrderDate > dateTime) // Tarih filtresi
				.Select(o => o.ProductId) // Sipariş edilen ürün ID'si
				.Distinct(); // Aynı ürünler tekrar edilmesin

			// Bu ID'lere karşılık gelen ürünleri listele
			var filteredProducts = products
				.Where(p => productIds.Contains(p.Id))
				.ToList();

			return filteredProducts; // Filtrelenmiş ürün listesi döndür
		}

	}
}
