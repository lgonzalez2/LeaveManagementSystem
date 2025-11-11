using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveTypesService
    {
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes();
        Task<LeaveTypeReadOnlyVM> GetLeaveType(int? id);
        Task CreateLeaveType(LeaveTypeCreateVM leaveTypeCreate);
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task RemoveLeaveType(int id);
    }
}