using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ControlSystemMessage.Models
{
    [Table("Messages")]
    public class MessagesModel : Messages
    {
        public int Count { get; set; }
        public bool IsSaved => IsImportant == 0 ;
        public FontAttributes FontStyle => IsRead == 0 ? FontAttributes.Bold : FontAttributes.None;
    }
}
