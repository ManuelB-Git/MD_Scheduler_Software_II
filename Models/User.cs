using SQLite;
namespace MD_Scheduler_Software_II.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [Unique]
        public int UserCompanyId { get; set; } = 0; 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
    }
}
