using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentWebApp.Data;
using AutoMapper;
using LeaveManagmentWebApp.Models;
using LeaveManagmentWebApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagmentWebApp.Constants;
// CRUD

// data model interact with database -> and then pass the data model to the view model with automapper
namespace LeaveManagmentWebApp.Controllers
{
    [Authorize(Roles = Roles.Administrator)] // first you need to be login(avtenticiran/authorize) to view the privacy page

    public class LeaveTypesController : Controller
    {
       
        //private readonly ApplicationDbContext _context; // breach to our database
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly iLeaveTypeRepositoty leaveTypeRepository;
        public LeaveTypesController(iLeaveTypeRepositoty leaveTypeRepositoty,
            IMapper mapper , 
            ILeaveAllocationRepository leaveAllocationRepository)
        {

           // _context = context; // connection of the database // Dependency injection se vika ova
            this.leaveTypeRepository = leaveTypeRepositoty;
            this._mapper = mapper;
            this.leaveAllocationRepository = leaveAllocationRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {

            var leaveTypes = _mapper.Map<List<LeaveTypeVM>>(await leaveTypeRepository.GetAllAsync()); // view model <-map datamodel
            //var leaveTypes = await _context.LeaveTypes.ToListAsync();
            return View(leaveTypes);/*SELECT * FROM LeaveTypes table */ // basicly mean this line LINQ mean
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
          
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /* POST IS EVERYTHINK THAT IS ENTER IN THE FORM IN THE URL */
        [HttpPost]
        [ValidateAntiForgeryToken] // for security perpouse generate token for the specif user who click the Create button

        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                await leaveTypeRepository.AddAsync(leaveType);
                return RedirectToAction(nameof(Index)); // nameof(Index) cause of speling error example it can be "Index"
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
                //return NotFound();
            //}

            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTypeVM = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id,LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(leaveTypeVM);
                    await leaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await leaveTypeRepository.Exists(leaveTypeVM.Id))
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
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        // if (id == null)
        //{
        //    return NotFound();
        // }

        // var leaveType = await _context.LeaveTypes
        //.FirstOrDefaultAsync(m => m.Id == id);
        //if (leaveType == null)
        // {
        //return NotFound();
        //}

        //return View(leaveType);
        //}

        // POST: LeaveTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var leaveType = await _context.LeaveTypes.FindAsync(id);
           // _context.LeaveTypes.Remove(leaveType);
            //await _context.SaveChangesAsync();
            await leaveTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // private async Task <bool> LeaveTypeExists(int id)
        // {
        //return await leaveTypeRepository.Exists(id);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id ) // this is the name that the button will be looking for(from the form in index in LeaveTypes)
        {
            await leaveAllocationRepository.LeaveAllocation(id);
            return RedirectToAction(nameof(Index));

        }


    }
}
