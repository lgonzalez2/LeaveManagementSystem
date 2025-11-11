using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Services;

public class LeaveTypesService(ApplicationDbContext context) : ILeaveTypesService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes()
    {
        // var data = SELECT * FROM LeaveTypes
        var data = await _context.LeaveTypes.ToListAsync();
        //convert the datamodel to a view model so as to not access the data model directly
        var viewData = data.Select(q => new LeaveTypeReadOnlyVM
        {
            Id = q.Id,
            Name = q.Name,
            NumberOfDays = q.NumberOfDays,
        }).ToList();
        
        return viewData;
    }

    public async Task<LeaveTypeReadOnlyVM> GetLeaveType(int? id)
    {
        // Select * from LeaveTypes WHERE Id = @id
        var data = await _context.LeaveTypes
            .FirstOrDefaultAsync(m => m.Id == id) ?? throw new KeyNotFoundException($"LeaveType with id {id} not found.");
        
        var viewData = new LeaveTypeReadOnlyVM
        {
            Id = data.Id,
            Name = data.Name,
            NumberOfDays = data.NumberOfDays,
        };

        return viewData;
    }

    public async Task CreateLeaveType(LeaveTypeCreateVM leaveTypeCreate)
    {
        var data = new LeaveType
        {
            Name = leaveTypeCreate.Name,
            NumberOfDays = leaveTypeCreate.NumberOfDays,
        };

        _context.Add(data);
        await _context.SaveChangesAsync();

        return;
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowercaseName = leaveTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName) && q.Id != leaveTypeEdit.Id);
    }

    public async Task RemoveLeaveType(int id)
    {
        var data = await _context.LeaveTypes.FindAsync(id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }

        return;
    }
}
