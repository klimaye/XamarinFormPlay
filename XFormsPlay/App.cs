using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace XFormsPlay
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			//return new MainPage ();
			return new PhoneWordPage ();
		}

		public class PhoneWordPage : ContentPage
		{
			Dictionary<string,int> letterMapping;
			string translate (string text)
			{
				if (string.IsNullOrWhiteSpace (text))
					return text;

				var output = "";
				foreach (char c in text) {					 
					if (Char.IsLetter (c)) {
						output += getNumberFor (c);
					} else {
						output += c;
					}
				}
				return output;
			}

			int getNumberFor(Char letter) {
				var upCaseLettter = letter.ToString ().ToUpper ();
				return letterMapping.First (X => X.Key.Contains (upCaseLettter)).Value;
			}

			void inititalizeMapping ()
			{
				letterMapping = new Dictionary<string, int> ();
				letterMapping.Add ("ABC", 2);
				letterMapping.Add ("DEF", 3);
				letterMapping.Add ("GHI", 4);
				letterMapping.Add ("JKL", 5);
				letterMapping.Add ("MNO", 6);
				letterMapping.Add ("PQR", 7);
				letterMapping.Add ("STU", 8);
				letterMapping.Add ("WXYZ", 9);
			}

			public PhoneWordPage ()
			{
				inititalizeMapping();
				Label label = new Label() {
					Text = " Enter Phone Number",
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Start
				};

				Entry txtPhoneNumber = new Entry() {
					Keyboard = Keyboard.Email,
					Placeholder = "phone number",
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Start
				};

				Button btnTranslate = new Button() {
					Text = "Translate",
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Start
				};

				Button btnCall = new Button() {
					Text = "Call",
					HorizontalOptions = LayoutOptions.Fill,
					VerticalOptions = LayoutOptions.Start
				};

				btnTranslate.Clicked += (sender, e) => {
					btnCall.Text =  "Call " + translate(txtPhoneNumber.Text);
				};

				var stackLayout = new StackLayout() {
					Padding = new Thickness(20,Device.OnPlatform(40,20,20), 20, 20),
					VerticalOptions = LayoutOptions.FillAndExpand,
					Spacing = 10
				};
				stackLayout.Children.Add(label);
				stackLayout.Children.Add(txtPhoneNumber);
				stackLayout.Children.Add(btnTranslate);
				stackLayout.Children.Add(btnCall);

				Content = stackLayout;
			}
		}

		public class MainPage : ContentPage
		{
			public MainPage ()
			{
				Label theLabel = new Label() {
					Text = " click ",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};

				Button theButton = new Button() {
					Text = "Click Me",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					VerticalOptions = LayoutOptions.CenterAndExpand
				};
				theButton.Clicked +=(sender, e) => {
					theLabel.Text = string.Format("{0} {1}"," click ",theLabel.Text);
				};

				DatePicker dtPicket = new DatePicker();

				var container = new StackLayout() {
					Padding = new Thickness(20, Device.OnPlatform(20,0,0),20,20)
				};

				container.Children.Add(dtPicket);
				container.Children.Add(theButton);
				container.Children.Add(theLabel);
				Content = new ScrollView() { Content = container };
			}

		}

	}
}

