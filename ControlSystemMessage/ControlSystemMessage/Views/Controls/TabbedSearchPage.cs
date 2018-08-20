using System.Windows.Input;
using Xamarin.Forms;

namespace ControlSystemMessage.Views.Controls
{
    public class TabbedSearchPage : TabbedPage
    {
        public static readonly BindableProperty SearchPlaceHolderTextProperty = BindableProperty.Create(nameof(SearchPlaceHolderText), typeof(string), typeof(TabbedSearchPage), string.Empty);
        public static readonly BindableProperty SearchTextProperty = BindableProperty.Create(nameof(SearchText), typeof(string), typeof(TabbedSearchPage), string.Empty);
        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(TabbedSearchPage));
        public static readonly BindableProperty ShowSearchProperty = BindableProperty.Create(nameof(ShowSearch), typeof(bool), typeof(TabbedSearchPage), true);


        public bool ShowSearch
        {
            get
            {
                return (bool)GetValue(ShowSearchProperty);
            }
            set
            {
                SetValue(ShowSearchProperty, value);
                OnPropertyChanged("CurrentPage");
            }
        }
        public string SearchPlaceHolderText
        {
            get
            {
                return (string)GetValue(SearchPlaceHolderTextProperty);
            }
            set
            {
                SetValue(SearchPlaceHolderTextProperty, value);
            }
        }

        public string SearchText
        {
            get
            {
                return (string)GetValue(SearchTextProperty);
            }
            set
            {
                SetValue(SearchTextProperty, value);

                var CurrentPage = this.CurrentPage;
                if (CurrentPage is SourceListPage)
                {
                    (CurrentPage as SourceListPage).SearchText(value);
                }
                else if (CurrentPage is MessageListPage) {
                    (CurrentPage as MessageListPage).SearchText(value);
                }
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return (ICommand)GetValue(SearchCommandProperty);
            }
            set
            {
                SetValue(SearchCommandProperty, value);
            }
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            var currentPage = this.CurrentPage;
            this.Title = this.CurrentPage.Title;
                

        }
    }
}

