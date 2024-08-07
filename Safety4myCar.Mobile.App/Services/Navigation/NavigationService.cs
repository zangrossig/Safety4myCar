using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.App.Services.Navigation
{
	public class NavigationService : INavigationService, INavigationInterceptor
	{
		public Task GotoLogin() => Navigate(Routes.AccountLogin);

		public Task GoBack() => Shell.Current.GoToAsync("..");

		public Task GotoRoot() => Shell.Current.Navigation.PopToRootAsync();

		public async Task GoBackAndReturn(Dictionary<string, object>? parameters)
		{
			await GoBack();

			if (Shell.Current.CurrentPage.BindingContext is INavigationParameterReceiver receiver)
			{
				await receiver.OnNavigatedTo(parameters);
			}
		}

		private async Task Navigate(string pageName, Dictionary<string, object>? parameters = null)
		{
			await Shell.Current.GoToAsync(pageName);

			if (Shell.Current.CurrentPage.BindingContext is INavigationParameterReceiver receiver)
			{
				await receiver.OnNavigatedTo(parameters);
			}
		}

		private WeakReference<INavigatedFrom>? previousFrom;

		public async Task OnNavigatedTo(object bindingContext, NavigationType navigationType)
		{
			if (previousFrom is not null && previousFrom.TryGetTarget(out INavigatedFrom? from))
			{
				await from.OnNavigatedFrom(navigationType);
			}

			if (bindingContext is INavigatedTo to)
			{
				await to.OnNavigatedTo(navigationType);
			}

			if (bindingContext is INavigatedFrom navigatedFrom)
			{
				previousFrom = new(navigatedFrom);
			}
			else
			{
				previousFrom = null;
			}
		}

		public Task<bool> CanNavigate(object bindingContext, NavigationType type)
		{
			if (bindingContext is INavigatable navigatable)
			{
				return navigatable.CanNavigateFrom(type);
			}

			return Task.FromResult(true);
		}
	}
}