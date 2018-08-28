using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;
using ControlSystemMessage.Models;
using Firebase.Iid;
using Firebase.Messaging;
using Xamarin.Forms;

namespace ControlSystemMessage.Droid
{
    [Activity(Label = "ControlSystemMessage", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Android.Support.V7.Widget.Toolbar ToolBar { get; private set; }
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
 
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            ToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (ToolBar != null)
            {
                SetSupportActionBar(ToolBar);
            }
            CreateNotificationChannel();
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            ToolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            return base.OnCreateOptionsMenu(menu);
        }
        protected override void OnResume()
        {
            base.OnResume();
            var Tocken = FirebaseInstanceId.Instance.Token;
        }
        void CreateNotificationChannel()
        {
            FirebaseMessaging.Instance.SubscribeToTopic("csmessage");

        }
    }
}

