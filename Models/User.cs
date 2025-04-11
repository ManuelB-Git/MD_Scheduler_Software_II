using SQLite;
using System.ComponentModel.DataAnnotations;
namespace MD_Scheduler_Software_II.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [Required, Unique]
        public string UserCompanyId { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string UserPassword { get; set; } = string.Empty;
    }
}
