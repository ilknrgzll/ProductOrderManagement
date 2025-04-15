using Core.Entities;

namespace Entities.Concrete
{
	public class Customer :BaseEntity, IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
	}
}
