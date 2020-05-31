using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms.Xaml;


namespace Mvvm.Xamarin
{
    public class DisplayNameExtension : IMarkupExtension<string>
    {
        public string TypeName { get; set; }

        public string PropertyName { get; set; }

        public DisplayNameExtension() { }


        public string ProvideValue(IServiceProvider serviceProvider)
        {
            var type = Type.GetType(TypeName);
            var prop = type?.GetProperty(PropertyName);
            var attributes = prop?.GetCustomAttribute(typeof(DisplayNameAttribute), false);
            return (attributes as DisplayNameAttribute)?.DisplayName;
        }


        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}