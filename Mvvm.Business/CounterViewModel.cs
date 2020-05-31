namespace Mvvm.Business
{
    public class CounterViewModel : BaseViewModel
    {
        public CounterViewModel()
        {
            Title = "Counter";
            ClickerLabel = "Click me";
        }
        
        
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public int CurrentCount
        {
            get => _currentCount;
            set => SetField(ref _currentCount, value);
        }


        public string ClickerLabel
        {
            get => _clickerLabel;
            set => SetField(ref _clickerLabel, value);
        }


        private string _title;
        private int _currentCount;
        private string _clickerLabel;
    }
}