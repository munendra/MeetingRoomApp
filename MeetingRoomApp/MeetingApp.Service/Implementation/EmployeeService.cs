using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Service.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeLogic _employeeLogic;
        public EmployeeService(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return await _employeeLogic.GetAllAsync();
        }
    }
}
