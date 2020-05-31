using Mvvm.Business.Models;


namespace Mvvm.Business
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }


        public Item Item { get; set; }


        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        private string _title;
    }
}