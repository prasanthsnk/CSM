using Android.App;
using Android.Content;
using Firebase.Messaging;
using ControlSystemMessage.Models;
using Xamarin.Forms;

namespace ControlSystemMessage.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "FirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            string json = message.Data["json"];
            if (json != null)
            {
                NotificationModel someObject = Newtonsoft.Json.JsonConvert.DeserializeObject<NotificationModel>(json);
                SendNotification(someObject);
            }
        }

         void SendNotification( NotificationModel someObject)
        {
            Intent notificationIntent = new Intent(this,typeof( MainActivity));
            notificationIntent.SetFlags(ActivityFlags.ClearTop  | ActivityFlags.SingleTop);
            PendingIntent contentIntent = PendingIntent.GetActivity(this, 0, notificationIntent, 0);
            Notification.Builder notificationBuilder = new Notification.Builder(this)
            .SetSmallIcon(Resource.Drawable.xamarin)
            .SetContentTitle(someObject.notification.title)
            .SetContentText(someObject.notification.text)
            .SetContentIntent(contentIntent)
            .SetAutoCancel(true);

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(111, notificationBuilder.Build());
            SaveMessage(someObject);
        }
        private async void SaveMessage(NotificationModel msg) {
            var Message = new Messages
            {

                Source = msg.to,
                Area = msg.Area,
                Title = msg.notification.title,
                NotificationText = msg.notification.text,
                wChangeMask = msg.data.wChangeMask + "",
                wNewState = msg.data.wNewState + "",
                ftTime = msg.data.ftTime,
                szMessage = msg.data.szMessage,
                dwEventType = msg.data.dwEventType + "",
                dwSeverity = msg.data.dwSeverity + "",
                szConditionName = msg.data.szConditionName,
                wQuality = msg.data.wQuality + "",
                //MessageszMessage = msg.mData.message.szMessage,
                bAckRequired = msg.data.bAckRequired ? 1 : 0
            };
            int id = await App.Database.SaveMessage(Message);
            MessagingCenter.Send<App>(App.AppInstance, "FCM");
        }

    }
}