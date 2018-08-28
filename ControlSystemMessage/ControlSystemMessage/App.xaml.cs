using ControlSystemMessage.Common;
using ControlSystemMessage.Data;
using ControlSystemMessage.Models;
using ControlSystemMessage.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ControlSystemMessage
{
    public partial class App : Application
    {
        public static ChatItemDatabase database;
        public static App AppInstance;
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
            //MainPage = new DemoPage();
            //MainPage =  new DashboardPage();
            // save();
            AppInstance = this;
            MainPage = new CustomNavigationPage(new DashboardPage());
        }

        private async void save() {

            Messages one = new Messages()
            {
                Source = "Motor1",
                Area = "Plant Area1",
                Title = "Motor1",
                NotificationText = "Power usage at high",
                wChangeMask = "0",
                wNewState = "1",
                ftTime = "11- 7-2018 11: 4:33",
                szMessage = "High power",
                dwEventType = "4",
                dwSeverity = "751",
                szConditionName = "High Voltage",
                wQuality = "0",
                MessageszMessage = "High Power"
            };
            await App.Database.SaveMessage(one);
            Messages two = new Messages()
            {
                Source = "Motor2",
                Area = "Plant Area1",
                Title = "Motor2",
                NotificationText = "Power usage at high",
                wChangeMask = "0",
                wNewState = "1",
                ftTime = "11- 7-2018 11: 4:33",
                szMessage = "High power",
                dwEventType = "4",
                dwSeverity = "751",
                szConditionName = "High Voltage",
                wQuality = "0",
                MessageszMessage = "High Power"
            };
            await App.Database.SaveMessage(two);
            Messages three = new Messages()
            {
                Source = "Motor3",
                Area = "Plant Area1",
                Title = "Motor3",
                NotificationText = "Power usage at high",
                wChangeMask = "0",
                wNewState = "1",
                ftTime = "11- 7-2018 11: 4:33",
                szMessage = "High power",
                dwEventType = "4",
                dwSeverity = "751",
                szConditionName = "High Voltage",
                wQuality = "0",
                MessageszMessage = "High Power"
            };
            await App.Database.SaveMessage(three);

            Messages Four = new Messages()
            {
                Source = "Motor3",
                Area = "Plant Area2",
                Title = "Motor3",
                NotificationText = "Power usage at high",
                wChangeMask = "0",
                wNewState = "1",
                ftTime = "11- 7-2018 11: 4:33",
                szMessage = "High power",
                dwEventType = "4",
                dwSeverity = "751",
                szConditionName = "High Voltage",
                wQuality = "0",
                MessageszMessage = "High Power"
            };
            await App.Database.SaveMessage(Four);
            Messages five = new Messages()
            {
                Source = "Motor1",
                Area = "Plant Area2",
                Title = "Motor1",
                NotificationText = "Power usage at high",
                wChangeMask = "0",
                wNewState = "1",
                ftTime = "11- 7-2018 11: 4:33",
                szMessage = "High power",
                dwEventType = "4",
                dwSeverity = "751",
                szConditionName = "High Voltage",
                wQuality = "0",
                MessageszMessage = "High Power"
            };
            await App.Database.SaveMessage(five);

        }
        protected override void OnStart()
        {
            // Handle when your app starts
            MessagingCenter.Subscribe<App>(this, "FCM", (sender) => {
                // do something whenever the "Hi" message is sent
                UpdateUi();
            });

            //CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
            //};
            //System.Diagnostics.Debug.WriteLine($"TOKEN: {CrossFirebasePushNotification.Current.Token}");

            //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Received");
            //    System.Diagnostics.Debug.WriteLine($"{p.Data}");

            //    NotificationModel someObject = ObjectExtensions.ToObject<NotificationModel>(p.Data);
            //    MData data = Newtonsoft.Json.JsonConvert.DeserializeObject<MData>(someObject.data);
            //    MNotification notification = Newtonsoft.Json.JsonConvert.DeserializeObject<MNotification>(someObject.notification);
            //    // Message message = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(someObject.message);

            //    someObject.mData = data;
            //    someObject.mNotification = notification;
            //    //someObject.mMessage = message;
            //    SaveAsync(someObject);
            //};

            //CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            //{
            //    //System.Diagnostics.Debug.WriteLine(p.Identifier);

            //    System.Diagnostics.Debug.WriteLine("Opened");
            //    System.Diagnostics.Debug.WriteLine($"{p.Data}");
            //};
            //CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("Dismissed");
            //};

        }

        public static ChatItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ChatItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sqlite.db"));
                }
                return database;
            }
        }
        private void UpdateUi()
        {
            var CurrentPage = (App.Current.MainPage as NavigationPage).CurrentPage;
            if (CurrentPage is DashboardPage)
            {
                (CurrentPage as DashboardPage).UpdateUiAsync("");
            }
            else if (CurrentPage is MessageListPage)
            {
                (CurrentPage as MessageListPage).SearchText("");
            }
            else if (CurrentPage is DetailedListPage)
            {
                (CurrentPage as DetailedListPage).Search("");
            }
        }
        private async void SaveAsync(NotificationModel msg)
        {
            var Message = new Messages
            {

                Source = msg.to,
                Area = msg.Area,
                Title = msg.title,
                NotificationText = msg.mNotification.text,
                wChangeMask = msg.mData.wChangeMask + "",
                wNewState = msg.mData.wNewState + "",
                ftTime = msg.mData.ftTime,
                szMessage = msg.mData.szMessage,
                dwEventType = msg.mData.dwEventType + "",
                dwSeverity = msg.mData.dwSeverity + "",
                szConditionName = msg.mData.szConditionName,
                wQuality = msg.mData.wQuality + "",
                //MessageszMessage = msg.mData.message.szMessage,
                bAckRequired = msg.mData.bAckRequired ? 1 : 0
            };

            int id = await App.Database.SaveMessage(Message);
            var CurrentPage = (App.Current.MainPage as NavigationPage).CurrentPage;
            if (CurrentPage is DashboardPage)
            {
                (CurrentPage as DashboardPage).UpdateUiAsync("");
            }
            else if (CurrentPage is MessageListPage)
            {
                (CurrentPage as MessageListPage).SearchText("");
            }
            else if (CurrentPage is DetailedListPage)
            {
                (CurrentPage as DetailedListPage).Search("");
            }
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
