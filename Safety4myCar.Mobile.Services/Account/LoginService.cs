using Safety4myCar.Mobile.Models.Repositories;
using Safety4myCar.Mobile.Models.Repositories.Account;
using Safety4myCar.Mobile.Services.Repositories;

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
						if (result.Data!.Value == LoginResultValue.Ok || result.Data!.Value == LoginResultValue.VerifyNeeded)
						{
							localAccountService.AuthToken = result.Data!.AuthToken;
						}
					}
				}

				return result;
			}

			return Result<LoginResult>.Fail("INTERNAL ERROR");
		}

		public async Task<Result<LoginResult>> TryLogin(string username, string password)
		{
			var result = await loginApiService.TryLogin(username, password);

			if (result.IsSuccess)
			{
				if (result.Data != null)
				{
					if (result.Data!.Value == LoginResultValue.Ok || result.Data!.Value == LoginResultValue.VerifyNeeded)
					{
						localAccountService.AuthToken = result.Data!.AuthToken;
						localAccountService.Credentials = new Models.Account.LocalCredentials
						{
							Username = username,
							Password = password
						};
						await localAccountService.Save();
					}
				}
			}

			return result;
		}
	}
}