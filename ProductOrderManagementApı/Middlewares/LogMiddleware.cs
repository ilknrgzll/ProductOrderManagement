namespace ProductOrderManagementApı.Middlewares
{
	public class LogMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<LogMiddleware> _logger;

		public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				string logFilePath = Path.Combine(Environment.CurrentDirectory, "Logs\\log.txt");
				long maxSizeBytes = 10 * 1024 * 1024; // 10MB olarak ayarlanmış maksimum boyut

				FileInfo logFileInfo = new FileInfo(logFilePath);
				if (logFileInfo.Exists)
				{
					using (var fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
					{
						await using (var streamWriter = new StreamWriter(fileStream))
						{
							await streamWriter.WriteLineAsync(
								$"Error: {ex.Message}\n" +
								$"Error Time: {DateTime.Now}\n" +
								$"Request {context.Request.Method}: {context.Request.Path} from {context.Connection.RemoteIpAddress}\n" +
								$"Stack Trace: {ex.StackTrace}\n\n\n"
							);

							if (logFileInfo.Length > maxSizeBytes)
							{
								fileStream.SetLength(0);
							}
						}
					}
				}
				_logger.LogError(ex, "Hata Oluştu");
				_logger.LogInformation($"Request {context.Request.Method}: {context.Request.Path} from {context.Connection.RemoteIpAddress}");
				_logger.LogWarning($"Request {context.Request.Method}: {context.Request.Path} from {context.Connection.RemoteIpAddress}");

				throw; // throw the exception to be caught by the ASP.NET Core pipeline
			}
		}
	}
}
