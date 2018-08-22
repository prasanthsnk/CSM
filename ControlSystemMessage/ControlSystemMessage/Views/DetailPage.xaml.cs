using ControlSystemMessage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlSystemMessage.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
        MessagesModel Message;
		public DetailPage (MessagesModel Message)
		{
			InitializeComponent ();
            this.Message = Message;
            this.BindingContext = Message;
            MarkRead();
        }
        private async void MarkRead() {
            int id = await App.Database.UpdateSingleColumnById("IsRead", "1",Message.ID);
        }
	}
}