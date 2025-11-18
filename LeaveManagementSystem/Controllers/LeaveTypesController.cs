using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using LeaveManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using LeaveManagementSystem.Common;

namespace LeaveManagementSystem.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController(ILeaveTypesService leaveTypesService) : Controller
    {
        private const string NameExistsValidationMessage = "This leave type already exists in the database";
        private readonly ILeaveTypesService _leaveTypesService = leaveTypesService;

        // GET: LeaveTypes
        // This pattern (Task<>) is specific to async
        public async Task<IActionResult> Index()
        {
            var viewData = await _leaveTypesService.GetAllLeaveTypes();

            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var viewData = await _leaveTypesService.GetLeaveType(id, data => new LeaveTypeReadOnlyVM
           {
            Id = data.Id,
            Name = data.Name,
            NumberOfDays = data.NumberOfDays
           });

            return View(viewData);
        }

        // GET: LeaveTypes/Create - just goes to the form
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create - depending on either POST/GET request, either this action or the above will happen respectively
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            // Can do additonal checks if there are no sufficient annotations to use in the VM
            if (await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                await _leaveTypesService.CreateLeaveType(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5 - goes to the form if the record exists
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _leaveTypesService.GetLeaveType(id, data => new LeaveTypeEditVM
            {
                Id = data.Id,
                Name = data.Name,
                NumberOfDays = data.NumberOfDays
            });

            return View(viewData);
        }

        // POST: LeaveTypes/Edit/5 - does the actual work
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypesService.CheckIfLeaveTypeNameExistsForEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypesService.EditLeaveType(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            // If there are any issues, this will return you to the form, which will include any inline errors
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5 - goes to the form if the record exists
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewData = await _leaveTypesService.GetLeaveType(id, data => new LeaveTypeReadOnlyVM
            {
                Id = data.Id,
                Name = data.Name,
                NumberOfDays = data.NumberOfDays
            });

            return View(viewData);
        }

        // POST: LeaveTypes/Delete/5 - does the actual work
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // Notice here that DeleteConfirmed is different from Delete up top (unlike Create and Edit, which are the same for both get and post)
        // this is because the parameters they take in are the same. So it wouldn't get overloaded, like methods who share the same name but have different parameters
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesService.RemoveLeaveType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
