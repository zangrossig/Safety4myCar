using RestSharp;
using RestSharp.Authenticators;
using Safety4myCar.Mobile.Repositories.Models;
using Safety4myCar.Mobile.Services.Shared;
using System.Text.Json;

namespace Safety4myCar.Mobile.Repositories
{
	public abstract class ApiGateway
	{
		protected ApiGateway(IConfigurationService configurationService, ILocalAccountService localAccountService)
		{
			ConfigurationService = configurationService;
			LocalAccountService = localAccountService;
		}

		public IConfigurationService ConfigurationService { get; }
		public ILocalAccountService LocalAccountService { get; }

		public async Task<Result<T>> Get<T>(string resource, bool anonymous = false)
		{
			var settings = new RestClientOptions(ConfigurationService.Data.Remote.HostUrl);
			if (!anonymous && !string.IsNullOrWhiteSpace(LocalAccountService.AuthToken))
			{
				settings.Authenticator = new JwtAuthenticator(LocalAccountService.AuthToken!);
			}

			var client = new RestClient(settings);
			var request = new RestRequest(resource, Method.Get);

			try
			{
				var response = await client.ExecuteAsync(request);
				if (response.IsSuccessStatusCode)
				{
					if (!string.IsNullOrWhiteSpace(response.Content))
					{
						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true,
						};
						var result = JsonSerializer.Deserialize<T>(response.Content!, options);
						if (result != null)
						{
							return Result<T>.Success(result);
						}
					}

					return Result<T>.Success();
				}
				else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
				{
					return Result<T>.Fail("UNAUTHORIZED", ResultFailure.NotAuthorized);
				}
				else
				{
					return Result<T>.Fail("FAILED_REQUEST", ResultFailure.RequestFailed);
				}
			}
			catch (Exception ex)
			{
				return Result<T>.Fail("INTERNAL ERROR", ResultFailure.InternalError);
			}
		}

		public async Task<Result<T>> Post<T>(string resource, object? data = null, bool anonymous = false)
		{
			var settings = new RestClientOptions(ConfigurationService.Data.Remote.HostUrl);
			if (!anonymous && !string.IsNullOrWhiteSpace(LocalAccountService.AuthToken))
			{
				settings.Authenticator = new JwtAuthenticator(LocalAccountService.AuthToken!);
			}

			var client = new RestClient(settings);
			var request = new RestRequest(resource, Method.Post);
			if (data != null)
			{
				request.AddJsonBody(data!);
			}

			try
			{
				var response = await client.ExecuteAsync(request);
				if (response.IsSuccessStatusCode)
				{
					if (!string.IsNullOrWhiteSpace(response.Content))
					{
						var options = new JsonSerializerOptions
						{
							PropertyNameCaseInsensitive = true,
						};
						var result = JsonSerializer.Deserialize<T>(response.Content!, options);
						if (result != null)
						{
							return Result<T>.Success(result);
						}
					}

					return Result<T>.Success();
				}
				else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
				{
					return Result<T>.Fail("UNAUTHORIZED", ResultFailure.NotAuthorized);
				}
				else
				{
					return Result<T>.Fail("FAILED_REQUEST", ResultFailure.RequestFailed);
				}
			}
			catch (Exception ex)
			{
				return Result<T>.Fail("INTERNAL ERROR", ResultFailure.InternalError);
			}
		}
	}
}