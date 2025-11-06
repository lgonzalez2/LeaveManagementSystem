using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace LeaveManagementSystem.Data
{
    public class LeaveType
    {
        public int Id {  get; set; }
        //This sets a specific type for the below column
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        public int NumberOfDays { get; set; }
    }
}
