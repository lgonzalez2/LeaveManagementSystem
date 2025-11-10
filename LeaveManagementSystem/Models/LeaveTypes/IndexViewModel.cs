namespace LeaveManagementSystem.Models.LeaveTypes
{
    // the attributes present here are what the view, itself, needs
    public class IndexViewModel
    {
        public int Id { get; set; }

        // Sets a default of empty string
        public string Name { get; set; } = string.Empty;

        public int NumberOfDays { get; set; }
    }
}
