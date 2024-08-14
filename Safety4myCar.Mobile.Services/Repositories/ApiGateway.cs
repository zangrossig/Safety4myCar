using RestSharp;
using RestSharp.Authenticators;
using Safety4myCar.Mobile.Models;
using Safety4myCar.Mobile.Services.Account;
using System.Text.Json;

namespace Safety4myCar.Mobile.Services.Repositories
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

		public async Task<Result<TDto>> Get<TDto>(string resource, bool anonymous = false)
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
						var resultDto = JsonSerializer.Deserialize<TDto>(response.Content!, options);
						if (resultDto != null)
						{
							return Result<TDto>.Success(resultDto);
						}
					}

					return Result<TDto>.Success();
				}
				else
				{
					return Result<TDto>.Fail("FAILED_REQUEST", response.StatusCode.ToString());
				}
			}
			catch (Exception ex)
			{
				return Result<TDto>.Fail(ex);
			}
		}

		public async Task<Result<TDto>> Post<TDto>(string resource, object? data = null, bool anonymous = false)
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
						var resultDto = JsonSerializer.Deserialize<TDto>(response.Content!, options);
						if (resultDto != null)
						{
							return Result<TDto>.Success(resultDto);
						}
					}

					return Result<TDto>.Success();
				}
				else
				{
					return Result<TDto>.Fail("FAILED_REQUEST", response.StatusCode.ToString());
				}
			}
			catch (Exception ex)
			{
				return Result<TDto>.Fail(ex);
			}
		}
	}
}