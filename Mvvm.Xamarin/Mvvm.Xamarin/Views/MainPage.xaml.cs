using Mvvm.Business;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Mvvm.Xamarin.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(MainViewModel viewModel, MenuPage menuPage, CounterPage counterPage,
            FetchDataPage fetchDataPage, HomePage homePage, ItemsPage itemsPage, AboutPage aboutPage)
        {
            _viewModel = viewModel;
            _counterPage = counterPage;
            _fetchDataPage = fetchDataPage;
            _homePage = homePage;
            _itemsPage = itemsPage;
            _aboutPage = aboutPage;
            InitializeComponent();
            BindingContext = viewModel;
            Master = menuPage;
            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int) MenuItemType.Home, (NavigationPage) Detail);
        }


        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
                switch (id)
                {
                    case (int) MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(_itemsPage));
                        break;
                    case (int) MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(_aboutPage));
                        break;
                    case (int) MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(_homePage));
                        break;
                    case (int) MenuItemType.Counter:
                        MenuPages.Add(id, new NavigationPage(_counterPage));
                        break;
                    case (int) MenuItemType.FetchData:
                        MenuPages.Add(id, new NavigationPage(_fetchDataPage));
                        break;
                }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }


        private readonly AboutPage _aboutPage;
        private readonly CounterPage _counterPage;
        private readonly FetchDataPage _fetchDataPage;
        private readonly HomePage _homePage;
        private readonly ItemsPage _itemsPage;
        private readonly MainViewModel _viewModel;
        private readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
    }
}