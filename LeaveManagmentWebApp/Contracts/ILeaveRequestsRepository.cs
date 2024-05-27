using LeaveManagmentWebApp.Data;
using LeaveManagmentWebApp.Models;

namespace LeaveManagmentWebApp.Contracts
{
    public interface ILeaveRequestsRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model);

        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();

        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);

        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);

        Task CancelLeaveRquest(int leaveReqestId);
        Task ChangeApprovalStatus(int leaveRequestsId, bool approved);
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
    }
}
