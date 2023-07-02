namespace TrustBank_DTOLayer.DTOs.CustomerAccountActivityDTOs
{
    public class CustomerSendMoneyDto
    {
        public string ActivityType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ActivityDate { get; set; }
        public string? ActivityDescription { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverAccountNumber { get; set; }
    }
}
