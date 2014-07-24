using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace XFormsPlay
{
	public class PhoneWordPage : ContentPage
	{
		private Entry txtPhoneNumber;
		private Button btnCallHistory;
		private List<string> callHistory = new List<string>();

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
				IsEnabled = false
			};

			btnCallHistory = new Button () {
				Text = "Call History",
				IsEnabled = false
			};
			btnCallHistory.Clicked += async (sender, e) => {
				await this.Navigation.PushAsync(new CallHistoryPage(callHistory));
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
			stackLayout.Children.Add (btnCallHistory);

			Content = stackLayout;
		}

		private async void onCall(object sender, EventArgs e) {
			var legitPhone = PhoneNumber.from (txtPhoneNumber.Text);
			if (await this.DisplayAlert (
				"Dial a number", "Would you like to call " + legitPhone.Number, 
				"Yes", "No")) {
				IDialer dialer = DependencyService.Get<IDialer> ();
				if (dialer != null) {
					btnCallHistory.IsEnabled = true;
					callHistory.Add (legitPhone.Number);
					dialer.call (legitPhone.Number);
				}
			}
		}
	}
}

