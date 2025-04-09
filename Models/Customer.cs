using SQLite;

namespace MD_Scheduler_Software_II.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public string CustomerState { get; set; } = string.Empty;
        public string CustomerPostalCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;


    }
}
