
namespace ControlSystemMessage.Models
{

    public class NotificationModel
    {
        public string to { get; set; }
        public string Area { get; set; }
        public Data data { get; set; }
        public Notification notification { get; set; }
    }
    public class Data
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

   

    public class Notification
    {
        public string title { get; set; }
        public string text { get; set; }
    }

   
}
