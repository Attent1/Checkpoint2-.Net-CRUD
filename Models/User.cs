using System.ComponentModel.DataAnnotations;

namespace Checkpont2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String UserName { get; set; } = String.Empty;
        public String UserEmail { get; set; } = String.Empty;
        public String UserPassword { get; set; } = String.Empty;
        public String UserOccupation { get; set; } = String.Empty;
    }
}
