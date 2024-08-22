using hdiYeterlilik.Models;

namespace hdiYeterlilik.Models
{
    public class Agreement
    {
        public int AgreementID { get; set; }
        public string AgreementName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

