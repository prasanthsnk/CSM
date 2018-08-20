using ControlSystemMessage.Models;
using ControlSystemMessage.ViewModels;
using ControlSystemMessage.Views.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            LoadData("");
            this.BindingContext = messagesViewModel;
        }
       
        private async void LoadData(string Search)
        {
            List<Messages> lstMsg = await App.Database.GetMessagesByQuery("SELECT * from Messages Where IsRead = '0' And Source Like '" + Search + "%'");
            messagesViewModel.MsgList = new ObservableCollection<Messages>(lstMsg);
        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
        public void SearchText(string Text)
        {
            LoadData(Text);
        }
    }
}