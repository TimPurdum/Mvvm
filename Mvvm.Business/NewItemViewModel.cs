using Mvvm.Business.Models;
using Mvvm.Business.Services;
using System.Windows.Input;


namespace Mvvm.Business
{
    public class NewItemViewModel : BaseViewModel
    {
        public NewItemViewModel(ItemsViewModel itemsViewModel, IDataStore<Item> dataStore)
        {
            DataStore = dataStore;
            _itemsViewModel = itemsViewModel;
            AddItemCommand = new RelayCommand(AddItem);

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };
        }


        public IDataStore<Item> DataStore { get; }


        public Item Item
        {
            get => _item;
            set => SetField(ref _item, value);
        }


        public ICommand AddItemCommand { get; }


        private async void AddItem(object o)
        {
            _itemsViewModel.Items.Add(Item);
            await DataStore.AddItemAsync(Item);
        }


        private readonly ItemsViewModel _itemsViewModel;
        private Item _item;
    }
}