using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.Controllers
{
    public class LeaveTypesController : Controller
    {
        //Dependency injection - recommended for maintainability
        private readonly ApplicationDbContext _context;
        private string NameExistsValidationMessage = "This leave type already exists in the database";

        public LeaveTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveTypes
        // This pattern (Task<>) is specific to async
        public async Task<IActionResult> Index()
        {
            // var data = SELECT * FROM LeaveTypes
            var data = await _context.LeaveTypes.ToListAsync();
            //convert the datamodel to a view model so as to not access the data model directly
            var viewData = data.Select(q => new LeaveTypeReadOnlyVM
            {
                Id = q.Id,
                Name = q.Name,
                NumberOfDays = q.NumberOfDays,
            });
            //return the view model to the view
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Select * from LeaveTypes WHERE Id = @id
            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var viewData = new LeaveTypeReadOnlyVM
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                NumberOfDays = leaveType.NumberOfDays,
            };

            return View(viewData);
        }

        // GET: LeaveTypes/Create - just goes to the form
        [HttpGet]
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
            if (await CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                var leaveType = new LeaveType
                {
                    Name = leaveTypeCreate.Name,
                    NumberOfDays = leaveTypeCreate.NumberOfDays,
                };

                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5 - goes to the form if the record exists
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var viewData = new LeaveTypeEditVM
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                NumberOfDays = leaveType.NumberOfDays,
            };

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

            if (ModelState.IsValid)
            {
                var leaveType = new LeaveType
                {
                    Id = leaveTypeEdit.Id,
                    Name = leaveTypeEdit.Name,
                    NumberOfDays = leaveTypeEdit.NumberOfDays,
                };

                try
                {
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveType.Id))
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
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var viewData = new LeaveTypeReadOnlyVM
            {
                Id = leaveType.Id,
                Name = leaveType.Name,
                NumberOfDays = leaveType.NumberOfDays,
            };

            return View(viewData);
        }

        // POST: LeaveTypes/Delete/5 - does the actual work
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // Notice here that DeleteConfirmed is different from Delete up top (unlike Create and Edit, which are the same for both get and post)
        // this is because the parameters they take in are the same. So it wouldn't get overloaded, like methods who share the same name but have different parameters
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // used in Exception catch block
        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        private async Task<bool> CheckIfLeaveTypeNameExists(string name)
        {
            var lowercaseName = name.ToLower();
            return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
        }
    }
}
