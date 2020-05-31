using System.Collections.ObjectModel;
using System.Windows.Input;


namespace Mvvm.Business
{
    public class NavMenuViewModel : BaseViewModel
    {
        public NavMenuViewModel()
        {
            ToggleNavMenuCommand = new RelayCommand(OnNavMenuToggle);
            NavTargets = new ObservableCollection<NavTarget>
            {
                new NavTarget("Home", "", ClassDisplayType.Home, MenuItemType.Home),
                new NavTarget("Counter", "counter", ClassDisplayType.Counter, MenuItemType.Counter),
                new NavTarget("Fetch data", "fetchdata", ClassDisplayType.List, MenuItemType.FetchData),
                new NavTarget("Browse", "browse", ClassDisplayType.List, MenuItemType.Browse),
                new NavTarget("About", "about", ClassDisplayType.Info, MenuItemType.About)
            };
        }


        public bool CollapseNavMenu
        {
            get => _collapseNavMenu;
            set => SetField(ref _collapseNavMenu, value);
        }


        public ObservableCollection<NavTarget> NavTargets
        {
            get => _navTargets;
            set => SetField(ref _navTargets, value);
        }


        public ICommand ToggleNavMenuCommand { get; }


        private void OnNavMenuToggle(object obj)
        {
            CollapseNavMenu = !CollapseNavMenu;
        }


        private bool _collapseNavMenu = true;
        private ObservableCollection<NavTarget> _navTargets;
    }
}