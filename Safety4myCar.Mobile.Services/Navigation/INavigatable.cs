namespace Safety4myCar.Mobile.Services.Navigation;

public interface INavigatable
{
	Task<bool> CanNavigateFrom(NavigationType navigationType);
}