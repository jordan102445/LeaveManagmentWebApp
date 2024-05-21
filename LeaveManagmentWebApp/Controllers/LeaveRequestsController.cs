using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentWebApp.Data;
using LeaveManagmentWebApp.Models;
using AutoMapper;
using LeaveManagmentWebApp.Contracts;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using LeaveManagmentWebApp.Constants;

namespace LeaveManagmentWebApp.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestsRepository leaveRequestsRepository;

        public LeaveRequestsController(ApplicationDbContext context,ILeaveRequestsRepository leaveRequestsRepository)
        {
            _context = context;
            this.leaveRequestsRepository = leaveRequestsRepository;
        }

        // GET: LeaveRequests

        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var model = await leaveRequestsRepository.GetAdminLeaveRequestList();
            //var applicationDbContext = _context.LeaveRequests.Include(l => l.LeaveType);
            return View(model);
        }

 
        public async Task<ActionResult> MyLeave()
        {
            var model = await leaveRequestsRepository.GetMyLeaveDetails();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
                //return NotFound();
            //}

            //var leaveRequest = await _context.LeaveRequests
                //.Include(l => l.LeaveType)
                //.FirstOrDefaultAsync(m => m.Id == id);
            //if (leaveRequest == null)
            //{
                //return NotFound();
            //}

            //return View(leaveRequest);

            var model = await leaveRequestsRepository.GetLeaveRequestAsync(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id,bool approved)
        {
            try
            {
                await leaveRequestsRepository.ChangeApprovalStatus(id, approved);

            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Cancel(int id,bool approved)
        {
            try
            {
                await leaveRequestsRepository.CancelLeaveRquest(id);
            }
            catch(Exception ex)
            {
                throw;
            }

            return RedirectToAction(nameof(MyLeave));
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name"),

        };
            //ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name"); // display the leaveTypeId(not as a id like a number the name of the leavetype)
            return View(model);                                                           // Specifically, it gets a list of different types of leave that people can request
                                                                                         // (like vacation, sick leave, etc.) from a database.
        }                                                                                // In this case, the SelectList is used to create a dropdown menu on a webpage
                                                                                         // where users can choose the type of leave they want to request.

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest = await leaveRequestsRepository.CreateLeaveRequest(model);
                    if(isValidRequest)
                    {
                        return RedirectToAction(nameof(MyLeave));
                    }
                    ModelState.AddModelError(string.Empty, "You have exceeded you allocation with this request.");
                   

                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An Error Has Occured.Please Try Again Later"); // this ocurr because we didnt do the mapping 
            }
            
            model.LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5 // if you want the user to modify,editing,etc the details of him you need always use the post method
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,LeaveTypeId,DateRequested,RequestComments,Approeved,Cancelled,RequestingEmployeeId,Id,DataCreated,DataModified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
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
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequests.Any(e => e.Id == id);
        }
    }
}
