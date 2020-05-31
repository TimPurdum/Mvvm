namespace Mvvm.Business
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            AppName = "MVVM Demo";
            Version = "1.0";
            Content = "This app is written in C# and native APIs using the <b>Xamarin Platform</b> and <b>Blazor</b>.\n" +
                      "It shares code with <b>iOS, Android, UWP, and Web</b> versions.";
            XamarinLink = "https://xamarin.com";
            BlazorLink = "https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor";
            ToCodeSoftwareLink = "https://tocode.software";
            XamarinIcon = "https://avatars2.githubusercontent.com/u/790012?s=200&v=4";
            BLazorIcon =
                "https://devblogs.microsoft.com/aspnet/wp-content/uploads/sites/16/2019/04/BrandBlazor_nohalo_1000x.png";
        }


        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }


        public string AppName
        {
            get => _appName;
            set => SetField(ref _appName, value);
        }


        public string Version
        {
            get => _version;
            set => SetField(ref _version, value);
        }


        public string Content
        {
            get => _content;
            set => SetField(ref _content, value);
        }
        

        public string XamarinLink
        {
            get => _xamarinLink;
            set => SetField(ref _xamarinLink, value);
        }
        
        
        public string BlazorLink
        {
            get => _blazorLink;
            set => SetField(ref _blazorLink, value);
        }
        
        
        public string ToCodeSoftwareLink
        {
            get => _toCodeSoftwareLink;
            set => SetField(ref _toCodeSoftwareLink, value);
        }


        public string XamarinIcon
        {
            get => _xamarinIcon;
            set => SetField(ref _xamarinIcon, value);
        }


        public string BLazorIcon
        {
            get => _blazorIcon;
            set => SetField(ref _blazorIcon, value);
        }


        private string _xamarinLink;
        private string _title;
        private string _blazorLink;
        private string _toCodeSoftwareLink;
        private string _appName;
        private string _version;
        private string _content;
        private string _xamarinIcon;
        private string _blazorIcon;
    }
}