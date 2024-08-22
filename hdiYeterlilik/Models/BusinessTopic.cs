namespace hdiYeterlilik.Models
{
    public class BusinessTopic
    {
        public int BusinessTopicID { get; set; }
        public int PartnerID { get; set; }
        public int AgreementID { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public DateTime SubmittedAt { get; set; }

        public Partner Partner { get; set; }
        public Agreement Agreement { get; set; }
    }
}
