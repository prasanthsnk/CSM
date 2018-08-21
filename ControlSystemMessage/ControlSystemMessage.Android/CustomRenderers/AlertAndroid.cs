using Android.App;
using Android.Widget;
using ControlSystemMessage.Common;
using ControlSystemMessage.Droid.CustomRenderers;

[assembly: Xamarin.Forms.Dependency(typeof(AlertAndroid))]
namespace ControlSystemMessage.Droid.CustomRenderers
{
    public class AlertAndroid : IAlert
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}