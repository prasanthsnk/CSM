 using SQLite;
using System.Windows.Input;

namespace ControlSystemMessage.Models
{
    [Table("Messages")]
    public class Messages
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Source { get; set; }
        public string Area { get; set; }
        public string Title { get; set; }
        public string NotificationText { get; set; }
        public string wChangeMask { get; set; }
        public string wNewState { get; set; }
        public string ftTime { get; set; }
        public string szMessage { get; set; }
        public string dwEventType { get; set; }
        public string dwSeverity { get; set; }
        public string szConditionName { get; set; }
        public string wQuality { get; set; }
        public string MessageszMessage { get; set; }
        public int IsRead { get; set; }
        public int bAckRequired { get; set; }
        public int IsImportant { get; set; }
    }
}
