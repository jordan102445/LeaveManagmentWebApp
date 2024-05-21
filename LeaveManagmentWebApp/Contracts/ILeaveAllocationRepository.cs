using LeaveManagmentWebApp.Data;
using LeaveManagmentWebApp.Models;

namespace LeaveManagmentWebApp.Contracts
{
    public interface  ILeaveAllocationRepository :IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation (int leaveTypeid);
        Task<bool> AllocationExists(string employeeId,int leaveTypeid,int period);

        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);
        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId);


        Task<LeaveAllocatiomEditVM> GetEmployeeAllocation(int id);

        Task <bool> UpdateEmployeeAllocation(LeaveAllocatiomEditVM model);


    }
}
