using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models.LeaveTypes
{
    // the attributes present here are what the view, itself, needs
    public class LeaveTypeReadOnlyVM: BaseLeaveTypeVM
    {
        // Sets a default of empty string
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
