using System;
using Xamarin.Forms;

namespace XFormsPlay
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new MainPage ();
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

