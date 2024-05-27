using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagmentWebApp.Constants;
using LeaveManagmentWebApp.Contracts;
using LeaveManagmentWebApp.Data;
using LeaveManagmentWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentWebApp.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Employee> userManager; // you need to interact direct with the user with userManager
        private readonly iLeaveTypeRepositoty leaveTypeRepositoty; // injection for to get DefaultDays  leaveType.DefaultDays
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context,
            UserManager<Employee> userManager, 
            iLeaveTypeRepositoty leaveTypeRepositoty,
            AutoMapper.IConfigurationProvider configurationProvider,
            IMapper mapper) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepositoty = leaveTypeRepositoty;
            this.configurationProvider = configurationProvider;
            this.mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeid, int period)
        {
            return await context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId
                                                           && q.LeaveTypeId == leaveTypeid
                                                           && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocation = await context.LeaveAllocations
                 .Include(q => q.LeaveType)// we run the query to get the allocations , we inner join with leaveType
                 .Where(q => q.EmployeeId == employeeId) // where will always bring a collection into like in this example list
                 .ProjectTo<LeaveAllocationVM>(configurationProvider) // it sees the data and do select of the data in same time,is optional
                 .ToListAsync(); // and we fillter with the employee that we are looking at 
            var employee = await userManager.FindByIdAsync(employeeId); // we fetch that employee record //details of the employee

            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee); // get me the view model,please complete the mapping between employee allocationsvm and the data class
            employeeAllocationModel.LeaveAllocations = allocation; // map the view allocations that we want to display(we return a view model here thats why we do the mapping)
            //employeeAllocationModel.LeaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocation); // map the view allocations that we want to display


            // we made the changes cause if we have 20 data of the employee username,firstname etc only got to map 5 of them and 15 is gonna go in a waste
            return employeeAllocationModel;
        }

        public async Task<LeaveAllocatiomEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await context.LeaveAllocations
                 .Include(q => q.LeaveType)// we run the query to get the allocations , we inner join with leaveType
                 .FirstOrDefaultAsync(q => q.Id == id); // we need only one allocation, give me the first record that matches the id that came in
           

            if(allocation == null)
            {
                return null;
            }

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId); // get the employee(ID)

            var model = mapper.Map<LeaveAllocatiomEditVM>(allocation); // return the data type of the employee(data of the employee return)
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(allocation.EmployeeId)); // and then map that allocation

            return model;
        }




        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepositoty.GetAsync(leaveTypeId); // injection for to get DefaultDays  leaveType.DefaultDays
            var allocations = new List<LeaveAllocation>();
            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                 allocations.Add (new LeaveAllocation // for each employee  build a leaveAllocation record
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });
            }
            await AddRangeAsync(allocations);//for better automatisation in the database (to add a range of allocation not one by one )


        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocatiomEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);

            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);// najdi go leave allocation za toj i toj employee
        }
    }
}
