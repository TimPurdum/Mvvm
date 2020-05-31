using Mvvm.Business.Models;
using Mvvm.Business.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;


namespace Mvvm.Business
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel(IDataStore<Item> dataStore)
        {
            DataStore = dataStore;
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new RelayCommand(ExecuteLoadItemsCommand);
        }


        public IDataStore<Item> DataStore { get; }


        public ObservableCollection<Item> Items { get; set; }
        public ICommand LoadItemsCommand { get; set; }


        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public bool IsBusy
        {
            get => _isBusy;
            set => SetField(ref _isBusy, value);
        }


        private async void ExecuteLoadItemsCommand(object o)
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items) Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        private bool _isBusy;


        private string _title;
    }
}