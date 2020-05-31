using Mvvm.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Mvvm.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPage : ContentPage
    {
        private readonly CounterViewModel _viewModel;


        public CounterPage(CounterViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
            _viewModel.CurrentCount++;
        }
    }
}