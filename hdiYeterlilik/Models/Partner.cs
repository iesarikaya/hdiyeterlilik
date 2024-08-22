namespace hdiYeterlilik.Models
{
    public class Partner
    {
        public int PartnerID { get; set; }
        public string PartnerName { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
