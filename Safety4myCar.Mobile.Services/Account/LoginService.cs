using Safety4myCar.Mobile.Models.Account;
using Safety4myCar.Mobile.Repositories;
using Safety4myCar.Mobile.Repositories.Models;
using Safety4myCar.Mobile.Services.Mappers;
using Safety4myCar.Mobile.Services.Shared;

namespace Safety4myCar.Mobile.Services.Account
{
	public interface ILoginService
	{
		Task<Result<LoginResult>> TryLogin(string username, string password);

		Task<Result<LoginResult>> TrySilentLogin();
	}

	public class LoginService : ILoginService
	{
		private readonly ILocalAccountService localAccountService;
		private readonly ILoginApiService loginApiService;

		public LoginService(ILocalAccountService localAccountService, ILoginApiService loginApiService)
		{
			this.localAccountService = localAccountService;
			this.loginApiService = loginApiService;
		}

		public async Task<Result<LoginResult>> TrySilentLogin()
		{
			if (localAccountService.Credentials != null && !string.IsNullOrWhiteSpace(localAccountService.Credentials.Username) && !string.IsNullOrWhiteSpace(localAccountService.Credentials.Password))
			{
				var result = await loginApiService.TryLogin(localAccountService.Credentials.Username, localAccountService.Credentials.Password);

				if (result.IsSuccess)
				{
					if (result.Data != null)
					{
						var loginResult = LoginMapper.MapLogin(result.Data!);
						if (loginResult != null)
						{
							if (loginResult!.Value == LoginResultValue.Ok || loginResult!.Value == LoginResultValue.VerifyNeeded)
							{
								localAccountService.AuthToken = loginResult!.AuthToken;
							}
							return Result<LoginResult>.Success(loginResult);
						}
					}

					return Result<LoginResult>.Success();
				}
			}

			return Result<LoginResult>.Fail("INTERNAL ERROR", ResultFailure.InternalError);
		}

		public async Task<Result<LoginResult>> TryLogin(string username, string password)
		{
			var result = await loginApiService.TryLogin(username, password);

			if (result.IsSuccess)
			{
				if (result.Data != null)
				{
					var loginResult = LoginMapper.MapLogin(result.Data!);

					if (loginResult!.Value == LoginResultValue.Ok || loginResult!.Value == LoginResultValue.VerifyNeeded)
					{
						localAccountService.AuthToken = loginResult!.AuthToken;
						localAccountService.Credentials = new LocalCredentials
						{
							Username = username,
							Password = password
						};
						await localAccountService.Save();

						return Result<LoginResult>.Success(loginResult);
					}
				}

				return Result<LoginResult>.Success();
			}

			return Result<LoginResult>.Fail("INTERNAL ERROR", ResultFailure.InternalError);
		}
	}
}