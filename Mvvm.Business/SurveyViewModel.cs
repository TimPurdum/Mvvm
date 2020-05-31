namespace Mvvm.Business
{
    public class SurveyViewModel : BaseViewModel
    {
        public SurveyViewModel()
        {
            Title = "How is Blazor and/or Xamarin.Forms working for you?";
            Link = "https://go.microsoft.com/fwlink/?linkid=2112271";
            Content = "Please take our <link>brief survey</link> and tell us what you think.";
        }
        
        
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public string Link
        {
            get => _link;
            set => SetField(ref _link, value);
        }


        public string Content
        {
            get => _content;
            set => SetField(ref _content, value);
        }


        private string _title;
        private string _link;
        private string _content;
    }
}