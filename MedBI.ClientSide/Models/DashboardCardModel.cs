namespace MedBI.ClientSide.Models
{
    public class DashboardCardModel
    {
        public string Title { get; set; } = "";
        public string ContentHtml { get; set; } = "";
        public int Width { get; set; } = 6; // Bootstrap columns (12 total)
    }
}
