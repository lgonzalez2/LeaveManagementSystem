namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        // Sets a default of empty string
        public string Name { get; set; } = string.Empty;

        public int NumberOfDays { get; set; }
    }
}
