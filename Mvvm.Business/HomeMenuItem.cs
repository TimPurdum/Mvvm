using System;
using System.Collections.Generic;
using System.Text;

namespace Mvvm.Business
{
    public enum MenuItemType
    {
        Browse,
        About,
        Home,
        Counter,
        FetchData
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
