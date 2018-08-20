using ControlSystemMessage.Common;
using ControlSystemMessage.Data;
using ControlSystemMessage.Models;
using ControlSystemMessage.Views;
using Plugin.FirebasePushNotification;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ControlSystemMessage
{
    public partial class App : Application
    {
        static ChatItemDatabase database;
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
            //MainPage = new DemoPage();
            //MainPage =  new DashboardPage();
          //  save();
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
            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
            };
            System.Diagnostics.Debug.WriteLine($"TOKEN: {CrossFirebasePushNotification.Current.Token}");

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Received");
                System.Diagnostics.Debug.WriteLine($"{p.Data}");

                ChatModel someObject = ObjectExtensions.ToObject<ChatModel>(p.Data);
                SaveAsync(someObject);
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                //System.Diagnostics.Debug.WriteLine(p.Identifier);

                System.Diagnostics.Debug.WriteLine("Opened");
                System.Diagnostics.Debug.WriteLine($"{p.Data}");
            };
            CrossFirebasePushNotification.Current.OnNotificationDeleted += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Dismissed");
            };

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

        private async void SaveAsync(ChatModel msg)
        {
            var Chat = new ChatModel
            {
                Message = msg.body,
                Type = 2,
                body = msg.body,
                title = msg.title,
                ImageUrl = msg.ImageUrl,
                Region = msg.Region,
            };

            int id = await App.Database.SaveItemAsync(Chat);
            var CurrentPage = (App.Current.MainPage as NavigationPage).CurrentPage;
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
