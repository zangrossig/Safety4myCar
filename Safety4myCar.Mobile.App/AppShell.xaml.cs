using Safety4myCar.Mobile.Services.Navigation;

namespace Safety4myCar.Mobile.App
{
	public partial class AppShell : Shell
	{
		private readonly INavigationInterceptor interceptor;

		public AppShell(INavigationInterceptor interceptor)
		{
			InitializeComponent();
			this.interceptor = interceptor;
		}

		protected override async void OnNavigated(ShellNavigatedEventArgs args)
		{
			var navigationType = GetNavigationType(args.Source);

			base.OnNavigated(args);

			await interceptor.OnNavigatedTo(CurrentPage?.BindingContext!, navigationType);
		}

		private NavigationType GetNavigationType(ShellNavigationSource source) =>
		source switch
		{
			ShellNavigationSource.Push or
			ShellNavigationSource.Insert
				=> NavigationType.Forward,
			ShellNavigationSource.Pop or
			ShellNavigationSource.PopToRoot or
			ShellNavigationSource.Remove
				=> NavigationType.Back,
			ShellNavigationSource.ShellItemChanged or
			ShellNavigationSource.ShellSectionChanged or
			ShellNavigationSource.ShellContentChanged
				=> NavigationType.SectionChange,
			_ => NavigationType.Unknown
		};
	}
}