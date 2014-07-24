using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace XFormsPlay
{
	public class CallHistoryPage : ContentPage
	{
		public CallHistoryPage (IEnumerable<string> history)
		{
			this.Title = "Call History";
			var listView = new ListView () {
				ItemsSource = history
			};
			this.Content = listView;
		}
	}
}

