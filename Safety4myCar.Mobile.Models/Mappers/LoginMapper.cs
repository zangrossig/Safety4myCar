using Safety4myCar.Mobile.Models.Account;
using Safety4myCar.Mobile.Models.Dto.Account;

namespace Safety4myCar.Mobile.Models.Mappers
{
	public static class LoginMapper
	{
		public static LoginResult MapLogin(LoginResultDto dto)
		{
			var value = LoginResultValue.Other;
			string? message = "Errore non specificato";

			switch (dto.Result)
			{
				case 0:
					value = LoginResultValue.Ok;
					message = null;
					break;

				case 1:
					value = LoginResultValue.AccountNotFound;
					message = "Utente non trovato";
					break;

				case 2:
					value = LoginResultValue.AccountDisabled;
					message = "Utente non attivo";
					break;

				case 3:
					value = LoginResultValue.PasswordWrong;
					message = "Password non corretta";
					break;

				case 4:
					value = LoginResultValue.VerifyNeeded;
					message = "Verifica necessaria";
					break;
			}

			return new LoginResult { Value = value, AuthToken = dto.Token, Message = message };
		}
	}
}