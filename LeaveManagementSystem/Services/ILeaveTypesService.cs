using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveTypesService
    {
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes();
        Task<LeaveTypeReadOnlyVM> GetLeaveType(int? id);
        Task<LeaveTypeEditVM> GetLeaveTypeEdit(int? id);
        Task CreateLeaveType(LeaveTypeCreateVM leaveTypeCreate);
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task EditLeaveType(LeaveTypeEditVM leaveTypeEdit);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task RemoveLeaveType(int id);
        bool LeaveTypeExists(int id);
    }
}