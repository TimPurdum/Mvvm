namespace Mvvm.Business
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(SurveyViewModel surveyViewModel)
        {
            Title = "Hello, world!";
            Content = "Welcome to your new app.";
            SurveyViewModel = surveyViewModel;
        }


        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public string Content
        {
            get => _content;
            set => SetField(ref _content, value);
        }


        public SurveyViewModel SurveyViewModel
        {
            get => _surveyViewModel;
            set => SetField(ref _surveyViewModel, value);
        }


        private string _content;
        private SurveyViewModel _surveyViewModel;
        private string _title;
    }
}