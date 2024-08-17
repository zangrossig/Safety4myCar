namespace Safety4myCar.Mobile.Services.Shared
{
	public interface IDialogService
	{
		Task Notify(string title, string message, string buttonText = "OK");

		Task<bool> AskYesNo(string title, string message, string trueButtonText = "Sì", string falseButtonText = "No");

		Task<string?> Ask(string title, string message, string acceptButtonText = "OK", string cancelButtonText = "Annulla");
	}
}