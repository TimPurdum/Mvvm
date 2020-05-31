using Mvvm.Business;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Mvvm.Xamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        private AboutViewModel _viewModel;


        public AboutPage()
        {
            InitializeComponent();
            _viewModel = (AboutViewModel) BindingContext;
            SetContent();
        }


        private void SetContent()
        {
            var content = _viewModel.Content;
            var formattedText = new FormattedString();

            while (content.Contains("<b>") && content.Length > 0)
            {
                var startOfBold = content.IndexOf("<b>", StringComparison.Ordinal);
                formattedText.Spans.Add(new Span{Text = content.Substring(0, startOfBold)});
                content = content.Substring(startOfBold + 3);
                var endOfBold = content.IndexOf("</b>", StringComparison.Ordinal);
                formattedText.Spans.Add(new Span
                {
                    Text = content.Substring(0, endOfBold),
                    FontAttributes = FontAttributes.Bold
                });
                content = content.Substring(endOfBold + 4);
            }
            
            formattedText.Spans.Add(new Span{Text = content});

            ContentLabel.FormattedText = formattedText;
        }


        private void XamarinLinkClicked(object sender, EventArgs e)
        {
            Browser.OpenAsync(_viewModel.XamarinLink);
        }
        
        
        private void BlazorLinkClicked(object sender, EventArgs e)
        {
            Browser.OpenAsync(_viewModel.BlazorLink);
        }
        
        
        private void ToCodeLinkClicked(object sender, EventArgs e)
        {
            Browser.OpenAsync(_viewModel.ToCodeSoftwareLink);
        }
    }
}