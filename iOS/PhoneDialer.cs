using System;
using Xamarin.Forms;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using XFormsPlay.iOS;

[assembly: Dependency(typeof(PhoneDialer))]
namespace XFormsPlay.iOS
{
	public class PhoneDialer : IDialer
	{
		public void call (string number)
		{
			UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number));
		}
	}
}

