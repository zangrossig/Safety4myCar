using System.Net;
using System.Text.Json;

namespace Safety4myCar.Mobile.Models.Repositories
{
	public class ApiResult<TData>
	{
		public ApiResult(HttpStatusCode statusCode, bool isSuccesful, string? content)
		{
			StatusCode = statusCode;
			IsSuccesful = isSuccesful;

			if (!string.IsNullOrWhiteSpace(content))
			{
				Data = JsonSerializer.Deserialize<TData>(content);
			}
		}

		public HttpStatusCode StatusCode { get; }
		public bool IsSuccesful { get; }
		public TData? Data { get; }
	}
}