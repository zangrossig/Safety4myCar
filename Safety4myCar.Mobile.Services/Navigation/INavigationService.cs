namespace Safety4myCar.Mobile.Services.Navigation;

public interface INavigationService
{
	Task GoBack();

	Task GoBackAndReturn(Dictionary<string, object> parameters);

	Task GotoLogin();

	Task GotoRoot();
}