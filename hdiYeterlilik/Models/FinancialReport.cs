namespace hdiYeterlilik.Models
{
    public class FinancialReport
    {
        public int FinancialReportID { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportContent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
