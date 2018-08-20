using ControlSystemMessage.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ControlSystemMessage.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public MessagesViewModel()
        {
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


        private ObservableCollection<Messages> msgList;

        public ObservableCollection<Messages> MsgList
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
    }
}
