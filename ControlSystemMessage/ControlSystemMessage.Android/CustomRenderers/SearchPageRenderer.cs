using Android.Runtime;
using Android.Text;
using Android.Views.InputMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Support.V7.Widget.SearchView;
using ControlSystemMessage.Droid.CustomRenderers;
using ControlSystemMessage.Views.Controls;
using Android.Content;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace ControlSystemMessage.Droid.CustomRenderers
{
    class SearchPageRenderer : PageRenderer
    {
        private SearchView _searchView;

        public SearchPageRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e?.NewElement == null || e.OldElement != null)
            {
                return;
            }

            AddSearchToToolBar();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(Page))
            {
                var maintoolbar = MainActivity.ToolBar;
                Xamarin.Forms.Device.BeginInvokeOnMainThread(delegate
                {
                    maintoolbar.Menu?.RemoveItem(Resource.Menu.mainmenu);
                    AddSearchToToolBar();
                });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_searchView != null)
            {
                _searchView.QueryTextChange += searchView_QueryTextChange;
                _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            }
            //toolBar?.Menu?.RemoveItem(Resource.Menu.mainmenu);
            base.Dispose(disposing);
        }


        private void AddSearchToToolBar()
        {
            if (Element == null)
            {
                return;
            }
            if (MainActivity.ToolBar == null)
            {

            }

            var toolBar =  MainActivity.ToolBar;

            toolBar.Title = Element.Title;
            toolBar.InflateMenu(Resource.Menu.mainmenu);

            _searchView = toolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.JavaCast<SearchView>();

            if (_searchView == null)
            {
                return;
            }

            _searchView.QueryTextChange += searchView_QueryTextChange;
            _searchView.QueryTextSubmit += searchView_QueryTextSubmit;
            _searchView.QueryHint = (Element as SearchPage)?.SearchPlaceHolderText;
            _searchView.ImeOptions = (int)ImeAction.Search;
            _searchView.InputType = (int)InputTypes.TextVariationNormal;
            _searchView.MaxWidth = int.MaxValue;        //Hack to go full width - http://stackoverflow.com/questions/31456102/searchview-doesnt-expand-full-width
        }

        private void searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            if (e == null)
            {
                return;
            }

            var searchPage = Element as SearchPage;
            if (searchPage == null)
            {
                return;
            }
            searchPage.SearchText = e.Query;
            searchPage.SearchCommand?.Execute(e.Query);
            e.Handled = true;
        }

        private void searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var searchPage = Element as SearchPage;
            if (searchPage == null)
            {
                return;
            }
            searchPage.SearchText = e?.NewText;
        }
    }
}