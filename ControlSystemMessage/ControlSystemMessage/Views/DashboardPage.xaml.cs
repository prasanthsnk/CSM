using ControlSystemMessage.Views.Controls;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlSystemMessage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : TabbedSearchPage
    {
        private static bool IsShown = false;
        public DashboardPage ()
        {
            InitializeComponent();
            Load();
        }
        private async void Load()
        {
            await Task.Delay(1000);
            if (!IsShown) {
                ShowSearch = true;
                IsShown = false;
            }
        }
        public void UpdateUiAsync(string id)
        {
            var CurrentPage = this.CurrentPage;
            if (CurrentPage is SourceListPage)
            {
                (CurrentPage as SourceListPage).SearchText("");
            }
            else if (CurrentPage is MessageListPage)
            {
                (CurrentPage as MessageListPage).SearchText("");
            }
            else if (CurrentPage is SavedMessagePage)
            {
                (CurrentPage as SavedMessagePage).SearchText("");
            }
        }
    }
}