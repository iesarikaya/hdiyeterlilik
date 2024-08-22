namespace hdiYeterlilik.Models
{
    public class RiskAnalysis
    {
        public int RiskAnalysisID { get; set; }
        public int TopicID { get; set; }
        public decimal RiskAmount { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string AnalysisResult { get; set; }

        public BusinessTopic BusinessTopic { get; set; }
    }
}
