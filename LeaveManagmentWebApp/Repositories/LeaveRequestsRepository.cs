using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagmentWebApp.Contracts;
using LeaveManagmentWebApp.Data;
using LeaveManagmentWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentWebApp.Repositories
{
    public class LeaveRequestsRepository : GenericRepository<LeaveRequest>,ILeaveRequestsRepository
    {
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor; // to get access of the type of the user information like id 
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;

        public LeaveRequestsRepository(ApplicationDbContext context, IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            AutoMapper.IConfigurationProvider configurationProvider,
            UserManager<Employee> userManager) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.configurationProvider = configurationProvider;
            this.leaveAllocationRepository = leaveAllocationRepository;
        }


        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User); // return or method to get the user
            //var leaveRequest = mapper.Map<LeaveRequest>(model); // create a map for that leaverequest 
            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);
            //leaveRequest.DateRequested = DateTime.Now;
            //leaveRequest.RequestingEmployeeId = user.Id;

            if(leaveAllocation == null)
            {
                return false;
            }
            int daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            if(daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }
            var leaveRequest = mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            return true;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await context.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(configurationProvider)
                .ToListAsync();
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User); // get the user who request a leave
            var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            // if this function wasnt made,it will be writed all over again the query like the lampbda function q=>
            // .LeaveAllocations it is trated like a one big object like allocation.LeaveAllocations -> is the data of the user(emoloyee)
            //var requests = mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));
            var requests = await GetAllAsync(user.Id); // replace of mapper is project to above
            //var requests =await GetAllAsync(user.Id);
            var model = new EmployeeLeaveRequestViewVM(allocations, requests);
            return model;
            
        }

        public async Task ChangeApprovalStatus(int leaveRequestsId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestsId); // get the request 
            leaveRequest.Approved = approved; // set it to be approved


            if (approved)
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays; // calculate requested days
                allocation.NumberOfDays -= daysRequested; // update the number of allocated day


                await leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            var approvalStatus = approved ? "Approved" : "Declined";

        }

        // Ensure GetEmployeeAllocation method is correct
        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            var allocation = await context.LeaveAllocations
                .FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);

            if (allocation == null)
            {
                // Log the values for debugging
                Console.WriteLine($"No allocation found for EmployeeId: {employeeId}, LeaveTypeId: {leaveTypeId}");
            }

            return allocation;
        }


        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                ReqjectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests),

            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            } // zima gi site leave request za site emoloyees

            return (model);
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await context.LeaveRequests
                .Include(q => q.LeaveType) // including the leave type with the details of the leave type 
                .FirstOrDefaultAsync(q => q.Id == id); // takes the leave Request associate with an id and with need to display the fields of the leave type                                                                                                            // and im finding the first or deafult id in the database that it matches with that id that it came

            if (leaveRequest == null)
            {
                return null;
            }
            var model = mapper.Map<LeaveRequestVM>(leaveRequest); // map it to handle it to the view model
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId)); // map it that leaveRequest for that employee that is came first like a thread
            return model;

        }

        public async Task CancelLeaveRquest(int leaveReqestId)
        {
             var leaveRequest = await GetAsync(leaveReqestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);
        }
    }
}
