using System.ComponentModel.DataAnnotations;

namespace Checkpont2.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public String UserName { get; set; } = String.Empty;
        [Required]
        [EmailAddress]
        public String UserEmail { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        public String UserPassword { get; set; } = String.Empty;

        public String UserOccupation { get; set; } = String.Empty;
    }
}
