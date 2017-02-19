using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlPreviewer
{
	public partial class StartPage : ContentPage
	{
		bool _animateOnStart = true;

		public StartPage()
		{
			InitializeComponent();
			BindingContext = new StartPageViewModel();
		}

		#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
		protected override async void OnAppearing()
		#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
		{
			base.OnAppearing();

			await AnimateIfNecessary();

			btnLogin.Clicked += BtnLogin_Clicked;
		}

		protected override void OnDisappearing()
		{
			btnLogin.Clicked -= BtnLogin_Clicked;
			base.OnDisappearing();
		}

		async Task AnimateIfNecessary()
		{
			if (!_animateOnStart) return;

			await InitializeControls();

			await imgStartLogo.ScaleTo(.2, 100, Easing.CubicOut);
			await imgStartLogo.ScaleTo(1.35, 750, Easing.SpringIn);
			await imgStartLogo.ScaleTo(1, 250, Easing.SpringOut);
			await imgStartLogo.TranslateTo(imgStartLogo.X, imgStartLogo.Y - (imgStartLogo.Height / 2));

			await btnLogin.FadeTo(1, 200);

			_animateOnStart = false;
		}

		async Task InitializeControls()
		{
			await Task.WhenAll(
				imgStartLogo.ScaleTo(0, 0),
				btnLogin.FadeTo(0, 0)
			);
		}

		async void BtnLogin_Clicked(object sender, System.EventArgs e)
		{
			var loginPage = new LoginPage();
			await Application.Current.MainPage.Navigation.PushAsync(loginPage);
		}
	}
}