using ControlSystemMessage.Common;
using ControlSystemMessage.Models;
using ControlSystemMessage.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ControlSystemMessage.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public MessagesViewModel()
        {
            SaveCommand = new Command<object>(OnSave);
            UnSaveCommand = new Command<object>(OnUnSave);
        }

        private List<string> system;

        public List<string> System
        {
            get { return system; }
            set
            {
                system = value;
                NotifyPropertyChanged("System");
            }
        }

        private List<string> area;

        public List<string> Area
        {
            get { return area; }
            set {
                area = value;
                NotifyPropertyChanged("Area");
            }
        }

        private ObservableCollection<MessagesModel> msgList;

        public ObservableCollection<MessagesModel> MsgList
        {
            get
            {
                return msgList;
            }
            set
            {
                    msgList = value;
                    NotifyPropertyChanged("MsgList");
            }
        }
        public Command<object> SaveCommand { get; set; }
        public Command<object> UnSaveCommand { get; set; }
        private void OnSave(object obj)
        {
            Update(obj, 1);
        }
        private void OnUnSave(object obj)
        {
            Update(obj, 0);
        }
        private async void Update(object obj ,int save ) {
            Messages message = (Messages)obj;
            message.IsImportant = save;
            await App.Database.SaveMessage(message);
            DependencyService.Get<IAlert>().ShortAlert(save == 1 ? "Messages Saved" : "Messages UnSave");
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
    }
}
