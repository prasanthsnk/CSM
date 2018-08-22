using ControlSystemMessage.Views.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ControlSystemMessage.Common
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page page) : base(page)
        {
            this.PropertyChanged += Handle_PropertyChanged;
        }

        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == NavigationPage.CurrentPageProperty.PropertyName)
            {
                if ((this.CurrentPage is TabbedSearchPage))
                {
                    (this.CurrentPage as TabbedSearchPage).ShowSearch = true;
                }
                else if ((this.CurrentPage is SearchPage))
                {
                    (this.CurrentPage as SearchPage).ShowSearch = true;
                }

            }
        }

    }
}

