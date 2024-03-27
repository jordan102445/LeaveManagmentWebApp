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
        }
    }
}
