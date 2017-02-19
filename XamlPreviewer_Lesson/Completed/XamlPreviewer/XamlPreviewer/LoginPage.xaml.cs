using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlPreviewer
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();

			InitializeControls();
		}

		#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
		protected override async void OnAppearing()
		#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
		{
			base.OnAppearing();

			await Task.WhenAll(
				txtEmail.FadeTo(1, 200),
				txtPassword.FadeTo(1, 200)
			);
		}

		void InitializeControls()
		{

			//await Task.WhenAll(
			//	txtEmail.FadeTo(0, 0),
			//	txtPassword.FadeTo(0, 0)
			//);
		}
	}
}
