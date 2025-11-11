using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveTypesService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task CreateLeaveType(LeaveTypeCreateVM leaveTypeCreate);
        Task EditLeaveType(LeaveTypeEditVM leaveTypeEdit);
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes();
        Task<T> GetLeaveType<T>(int? id, Func<LeaveType, T> map) where T : class;
        bool LeaveTypeExists(int id);
        Task RemoveLeaveType(int id);
    }
}