using Mvvm.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mvvm.Xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        private readonly NavMenuViewModel _viewModel;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage(NavMenuViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = viewModel;

            menuItems = new List<HomeMenuItem>();
            foreach (var target in viewModel.NavTargets)
            {
                menuItems.Add(new HomeMenuItem{Id = target.MenuItemType, Title= target.Label });
            }

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}