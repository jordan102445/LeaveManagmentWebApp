using AutoMapper;
using LeaveManagmentWebApp.Data;
using LeaveManagmentWebApp.Models;

namespace LeaveManagmentWebApp.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<Employee, EmployeeListVM>().ReverseMap();
            CreateMap<Employee, EmployeeAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocatiomEditVM>().ReverseMap();


        }
    }
}
