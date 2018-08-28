using System;
using System.IO;
using Android.App;
using Android.Runtime;
using ControlSystemMessage.Data;

namespace ControlSystemMessage.Droid
{
    [Application]
    class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //If debug you should reset the token each time.
//#if DEBUG
//            FirebasePushNotificationManager.Initialize(this, true);
//#else
  //          FirebasePushNotificationManager.Initialize(this, false);
//#endif
            //Handle notification when app is closed here
            //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            //{


            //};
        }
    }
}