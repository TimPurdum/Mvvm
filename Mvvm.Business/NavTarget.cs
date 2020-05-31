namespace Mvvm.Business
{
    public class NavTarget
    {
        public NavTarget(string label, string link, ClassDisplayType classType, MenuItemType menuItemType)
        {
            Label = label;
            Link = link;
            ClassType = classType;
            MenuItemType = menuItemType;
        }


        public string Label { get; }
        public string Link { get; }
        public ClassDisplayType ClassType { get; }
        public MenuItemType MenuItemType { get; }
    }


    public enum ClassDisplayType
    {
        Home,
        Counter,
        List,
        Info
    }
}