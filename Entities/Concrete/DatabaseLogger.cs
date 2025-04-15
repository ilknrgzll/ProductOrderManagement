using Core.Entities;

namespace Entities.Concrete
{
	public class DatabaseLogger : ILogger
	{
		public void Log(string message)
		{
			// Log to a database (implementation depends on context)
			Console.WriteLine("Database log: " + message);
		}
	}
}
