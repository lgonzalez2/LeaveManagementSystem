using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        // These annotations are for UI validations (not model/data validation)
        [Required]
        [Length(4, 150, ErrorMessage ="You have violated the length requirements")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 99)]
        public int NumberOfDays { get; set; }
    }
}
