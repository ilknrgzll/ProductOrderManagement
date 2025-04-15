using Core.Entities;

namespace Entities.Concrete
{
	public class BaseEntity:IEntity
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
