using ControlSystemMessage.Models;
using ControlSystemMessage.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlSystemMessage.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessageListPage : ContentPage
    {
        MessagesViewModel messagesViewModel;

        public MessageListPage()
        {  
            InitializeComponent();
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
            List<MessagesModel> lstMsg = await App.Database.GetMessagesByQuery("SELECT * from Messages Where IsRead = '0' And (Source Like '" + Search + "%'  OR NotificationText like '%" + Search + "%')");
            messagesViewModel.MsgList = new ObservableCollection<MessagesModel>(lstMsg);
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MessagesModel item)
            {
                Navigation.PushAsync(new DetailPage(item));
                ((ListView)sender).SelectedItem = null;
            }
        }
        public void SearchText(string Text)
        {
            LoadData(Text);
        }
    }
}