using ControlSystemMessage.Models;
using System.Collections.ObjectModel;

namespace ControlSystemMessage.ViewModels
{
    class ChatViewModel : BaseViewModel
    {
        public ChatViewModel()
        {
        }

        private ObservableCollection<ChatModel> chatList;

        public ObservableCollection<ChatModel> ChatList
        {
            get
            {
                return this.chatList;
            }
            set
            {
                    this.chatList = value;
                    NotifyPropertyChanged("ChatList");
            }
        }
    }
}
