using Mvvm.Business;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Mvvm.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FetchDataPage : ContentPage
    {
        private readonly FetchDataViewModel _viewModel;


        public FetchDataPage(FetchDataViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            BindingContext = viewModel;
            Task.Run(async () => await viewModel.GetForecastAsync(DateTime.Now));
        }
    }
}