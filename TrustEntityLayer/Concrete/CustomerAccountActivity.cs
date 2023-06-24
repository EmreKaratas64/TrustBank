namespace TrustBank_EntityLayer.Concrete
{
    public class CustomerAccountActivity
    {
        public int CustomerAccountActivityID { get; set; }
        public string ActivityType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityDescription { get; set; }
    }
}
