using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.Account
{
    public class VerifyEmailVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
