using ControlSystemMessage.Common;
using ControlSystemMessage.Models;
using ControlSystemMessage.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlSystemMessage.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SourceListPage : ContentPage
	{
        private MessagesViewModel messagesViewModel;
        private string selectedArea = "", selectedSystem = "";
        private bool flagSelected = false;
        public SourceListPage()
        {
            InitializeComponent();
            messagesViewModel = new MessagesViewModel();
            this.BindingContext = messagesViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData("");
        }
        private async void LoadData(string SearchText)
        {
            string source = selectedSystem.Equals(Constants.SELECT_SYSTEM) ? "" : selectedSystem;
            string area = selectedArea.Equals(Constants.SELECT_PLANT_AREA) ? "" : selectedArea;
            string query = "SELECT msg.* , (Select count(*) from Messages Where Source = msg.Source And Area = msg.Area And IsRead =0) as count from Messages as msg Where (Source LIKE '" + SearchText + "%'  OR NotificationText like '%" + SearchText + "%') "
                + "And Source " + (source.Equals("") ? "LIKE '%" + source + "%'" : " = '" + source + "'") + " And Area " + (area.Equals("") ? "LIKE '%" + area + "%'" : " = '" + area + "'") + " GROUP BY Area , Source";
            
 
            List<MessagesModel> lstMsgs = await App.Database.GetMessagesByQuery(query);
            messagesViewModel.MsgList = new ObservableCollection<MessagesModel>(lstMsgs);

            if (selectedArea .Equals(""))
            {
                List<MessagesModel> lstAreas = await App.Database.GetMessagesByQuery(Constants.QRY_AREAS);
                List<string> areas = new List<string>
                {
                    Constants.SELECT_PLANT_AREA
                };
                foreach (MessagesModel msg in lstAreas)
                {
                    areas.Add(msg.Area);
                }
                messagesViewModel.Area = areas;

                List<MessagesModel> lstSystems = await App.Database.GetMessagesByQuery(Constants.QRY_AREAS);

                List<string> System = new List<string>
                {
                   Constants.SELECT_SYSTEM
                };
                foreach (MessagesModel msg in lstSystems)
                {
                    System.Add(msg.Source);
                }
                messagesViewModel.System = System;

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (!flagSelected && messagesViewModel.System.Count > 0
                    && messagesViewModel.Area.Count > 0)
                    {
                        AreaPicker.SelectedIndex = 0;
                        SystemPicker.SelectedIndex = 0;
                        flagSelected = true;
                    }
                });

                //if (lstAreas.Count > 0) {
                //    selectedArea = lstAreas[0].Area;
                //}
            }

        }
        private void OnSelectedIndexChangedArea(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var SelectedIndex = picker.SelectedIndex;
            if (SelectedIndex != -1)
            {
                selectedArea =  picker.Items[SelectedIndex];
                LoadData("");
            }
            
        }
        private void OnSelectedIndexChangedSystem(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            var SelectedIndex = picker.SelectedIndex;
            if (SelectedIndex != -1)
            {
                selectedSystem = picker.Items[SelectedIndex];
                LoadData("");
            }

        }
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Messages item)
            {
                Navigation.PushAsync(new DetailedListPage(item.Source,item.Area));
                ((ListView)sender).SelectedItem = null;
            }
        }
        public void SearchText(string Text) {
            LoadData(Text);
        }
    }
}