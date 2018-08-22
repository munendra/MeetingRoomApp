using MeetingApp.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Service.Contract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}
