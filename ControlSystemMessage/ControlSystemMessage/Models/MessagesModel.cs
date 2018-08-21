using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlSystemMessage.Models
{
    [Table("Messages")]
    public class MessagesModel : Messages
    {
        public int Count { get; set; }
        public bool IsSaved => IsImportant == 0 ;
    }
}
