using ControlSystemMessage.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlSystemMessage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : TabbedSearchPage
    {
        public DashboardPage ()
        {
            InitializeComponent();
        }
        public void UpdateUiAsync(int id)
        {

        }
    }
}