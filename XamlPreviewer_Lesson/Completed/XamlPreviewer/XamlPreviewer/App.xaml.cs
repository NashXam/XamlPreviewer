using Xamarin.Forms;

namespace XamlPreviewer
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var startPage = new StartPage();

			var nav = new NavigationPage(startPage)
			{
				BarBackgroundColor = (Color)Resources["steelBlue"]
			};
			NavigationPage.SetHasNavigationBar(startPage, false);

			MainPage = nav;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
