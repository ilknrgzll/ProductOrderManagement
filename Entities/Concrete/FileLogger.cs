using Core.Entities;
namespace Entities.Concrete
{
	public class FileLogger : ILogger
	{
		public void Log(string message)
		{
			// Log to a file
			File.AppendAllText("log.txt", message + Environment.NewLine);
		}
	}
}
