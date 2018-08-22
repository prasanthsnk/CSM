using ControlSystemMessage.Models;
using ControlSystemMessage.ViewModels;
using ControlSystemMessage.Views.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlSystemMessage.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailedListPage : SearchPage
	{
        MessagesViewModel messagesViewModel;
        private string Source, Area;
        public DetailedListPage(string Source, string Area)
        {
            InitializeComponent();
            this.Source = Source;
            this.Area = Area;
            messagesViewModel = new MessagesViewModel();
            this.BindingContext = messagesViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData("");
        }
        private async void LoadData(string Search)
        {
            List<MessagesModel> listMsgs = await App.Database.GetMessagesByQuery("SELECT * from Messages Where Area = '" + Area + "' AND Source = '" + Source + "' AND (Source Like '" + Search + "%'  OR NotificationText like '%" + Search + "%')");
            messagesViewModel.MsgList = new ObservableCollection<MessagesModel>(listMsgs);
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MessagesModel item)
            {
                Navigation.PushAsync(new DetailPage(item));
                ((ListView)sender).SelectedItem = null;
            }
        }
        public void Search(string Text)
        {
            LoadData(Text);
        }
    }
}