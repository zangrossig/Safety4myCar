using Safety4myCar.Mobile.Models.Dto.Account;
using Safety4myCar.Mobile.Models.Mappers;
using Safety4myCar.Mobile.Models.Repositories;
using Safety4myCar.Mobile.Models.Repositories.Account;
using Safety4myCar.Mobile.Services.Account;

namespace Safety4myCar.Mobile.Services.Repositories
{
	public interface ILoginApiService
	{
		Task<Result<LoginResult>> TryLogin(string username, string password);
	}

	public class LoginApiService : ApiGateway, ILoginApiService
	{
		public LoginApiService(IConfigurationService configurationService, ILocalAccountService localAccountService) : base(configurationService, localAccountService)
		{
		}

		public async Task<Result<LoginResult>> TryLogin(string username, string password)
		{
			var loginInfo = new LoginInfoDto
			{
				Username = username,
				Password = password
			};

			var result = await Post<LoginResult, LoginResultDto>("Account/Login", LoginMapper.MapLogin, loginInfo);

			return result;
		}
	}
}