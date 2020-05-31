using Mvvm.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Mvvm.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveyView : ContentView
    {
        public SurveyView()
        {
            BindingContextChanged += SetLinkText;
            InitializeComponent();
        }


        private void SetLinkText(object sender, EventArgs e)
        {
            var vm = BindingContext as SurveyViewModel;
            if (vm == null) return;
            var text = vm.Content;
            var link = vm.Link;
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(link)) return;
            
            var formatted = new FormattedString();

            while (text.Length > 0 && text.Contains("<link>"))
            {
                var linkStarts = text.IndexOf("<link>", StringComparison.Ordinal);
                formatted.Spans.Add(new Span{Text = text.Substring(0, linkStarts)});
                text = text.Substring(linkStarts + 6);
                var linkEnds = text.IndexOf("</link>");
                formatted.Spans.Add(new Span
                {
                    Text = text.Substring(0, linkEnds),
                    ForegroundColor = Color.Blue,
                    GestureRecognizers =
                    {
                        new TapGestureRecognizer
                        {
                            Command = _navigationCommand,
                            CommandParameter = link
                        }
                    }
                });
                text = text.Substring(linkEnds + 7);
            }
            formatted.Spans.Add(new Span{Text = text});

            LinkLabel.FormattedText = formatted;
        }
        
        
        private readonly ICommand _navigationCommand = new Command<string>(async (url) =>
        {
            await Browser.OpenAsync(new Uri(url));
        });
    }
}