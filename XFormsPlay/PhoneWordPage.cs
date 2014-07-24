using System;
using Xamarin.Forms;

namespace XFormsPlay
{
	public class PhoneWordPage : ContentPage
	{
		private Entry txtPhoneNumber;
		public PhoneWordPage ()
		{
			this.Title = "Phone Word";
			Label label = new Label() {
				Text = " Enter Phone Number",
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start
			};

			txtPhoneNumber = new Entry() {
				Keyboard = Keyboard.Email,
				Placeholder = "phone number",
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start
			};					

			Button btnCall = new Button() {
				Text = "Call",
				IsEnabled = false,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start
			};


			txtPhoneNumber.TextChanged +=(object sender, TextChangedEventArgs e) => {
				var legitPhone = PhoneNumber.from(e.NewTextValue);
				btnCall.IsEnabled = legitPhone.IsValid();
				if (legitPhone.IsValid()) {
					btnCall.Text =  "Call " + legitPhone.Number;
				}
			};

			btnCall.Clicked += onCall;

			var stackLayout = new StackLayout() {
				Padding = new Thickness(20,Device.OnPlatform(40,20,20), 20, 20),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10
			};
			stackLayout.Children.Add(label);
			stackLayout.Children.Add(txtPhoneNumber);
			stackLayout.Children.Add(btnCall);

			Content = stackLayout;
		}

		private async void onCall(object sender, EventArgs e) {
			var legitPhone = PhoneNumber.from (txtPhoneNumber.Text);
			if (await this.DisplayAlert (
				"Dial a number", "Would you like to call " + legitPhone.Number, 
				"Yes", "No")) {
				IDialer dialer = DependencyService.Get<IDialer> ();
				dialer.call (legitPhone.Number);
			}
		}
	}
}

