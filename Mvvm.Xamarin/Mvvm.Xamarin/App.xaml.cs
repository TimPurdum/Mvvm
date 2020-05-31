using Microsoft.Extensions.DependencyInjection;
using Mvvm.Business;
using Mvvm.Business.Data;
using Mvvm.Business.Models;
using Mvvm.Business.Services;
using Xamarin.Forms;
using Mvvm.Xamarin.Views;


namespace Mvvm.Xamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            var serviceProvider = new ServiceCollection()
                .AddSingleton<MainViewModel>()
                .AddSingleton<NavMenuViewModel>()
                .AddSingleton<SurveyViewModel>()
                .AddSingleton<FetchDataViewModel>()
                .AddSingleton<CounterViewModel>()
                .AddSingleton<NewItemViewModel>()
                .AddSingleton<ItemsViewModel>()
                .AddSingleton<AboutViewModel>()
                .AddSingleton<MainPage>()
                .AddSingleton<MenuPage>()
                .AddSingleton<ItemsPage>()
                .AddSingleton<CounterPage>()
                .AddSingleton<FetchDataPage>()
                .AddSingleton<HomePage>()
                .AddSingleton<AboutPage>()
                .AddSingleton<NewItemPage>()
                .AddSingleton<IDataStore<Item>, MockDataStore>()
                .AddSingleton<WeatherForecastService>()
                .BuildServiceProvider();
            MainPage = serviceProvider.GetService<MainPage>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
