using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveTypesService
    {
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes();
        Task<LeaveTypeReadOnlyVM> GetLeaveType(int? id);
        Task RemoveLeaveType(int id);
    }
}