using Mvvm.Business;
using Mvvm.Business.Models;
using Mvvm.Business.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;


namespace Mvvm.Xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage(ItemsViewModel ivm, IDataStore<Item> dataStore)
        {
            _dataStore = dataStore;
            InitializeComponent();

            BindingContext = _viewModel = ivm;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Items.Count == 0)
                _viewModel.IsBusy = true;
        }


        private async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject) sender;
            var item = (Item) layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }


        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(
                new NavigationPage(new NewItemPage(new NewItemViewModel(_viewModel, _dataStore))));
        }


        private readonly IDataStore<Item> _dataStore;
        private readonly ItemsViewModel _viewModel;
    }
}