
namespace ControlSystemMessage.Models
{

    public class NotificationModel
    {
        public string to { get; set; }
        public string Area { get; set; }
        public MData mData { get; set; }
        public MNotification mNotification { get; set; }

        public string data { get; set; }
        public string notification { get; set; }
        public string sound { get; set; }

        public string body { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public Message mMessage { get; set; }

    }
    public class MData
    {
        public int wChangeMask { get; set; }
        public int wNewState { get; set; }
        public string ftTime { get; set; }
        public string szMessage { get; set; }
        public int dwEventType { get; set; }
        public int dwSeverity { get; set; }
        public string szConditionName { get; set; }
        public int wQuality { get; set; }
        public bool bAckRequired { get; set; }
        public Message message { get; set; }
    }

    public class Message
    {
        public string szMessage { get; set; }
    }

   

    public class MNotification
    {
        public string title { get; set; }
        public string text { get; set; }
    }

   
}
