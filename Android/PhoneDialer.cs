using System;
using Xamarin.Forms;
using Android.Util;
using Android.Content;
using Android.Net;
using XFormsPlay.Android;
using Uri = Android.Net.Uri;
using Android.Telephony;
using System.Linq;

[assembly: Dependency(typeof(PhoneDialer))]
namespace XFormsPlay.Android
{
	public class PhoneDialer : IDialer
	{
		public static Context ApplicationContext { get; set; }
		#region IDialer implementation

		public void call (string number)
		{
			if (ApplicationContext == null)
				return;
			var uri = Uri.Parse("tel:" + number);
			var intent = new Intent (Intent.ActionView, uri); 
			if (IsIntentAvailable (ApplicationContext, intent)) {
				ApplicationContext.StartActivity (intent);
			}
		}

		/// <summary>
		/// Checks if an intent can be handled.
		/// </summary>
		public static bool IsIntentAvailable(Context context, Intent intent)
		{
			var packageManager = context.PackageManager;

			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;

			TelephonyManager mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
		}

		#endregion
	}
}

