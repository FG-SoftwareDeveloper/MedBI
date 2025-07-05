namespace MedBI.ClientSide.Models
{
    public class NavigationItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconCssClass { get; set; }
        public string PageUrl { get; set; }
        public int Order { get; set; }
    }
}
