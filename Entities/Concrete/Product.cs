using Core.Entities;

namespace Entities.Concrete
{
	public class Product :BaseEntity,IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}
