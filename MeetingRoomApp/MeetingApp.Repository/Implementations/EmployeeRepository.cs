using MeetingApp.Domain.Entities;
using MeetingApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IBaseRepository<Employee> _employeeBaseRepository;
        public EmployeeRepository(IBaseRepository<Employee> baseRepository)
        {
            _employeeBaseRepository = baseRepository;
        }

        public async Task<Employee> GetIdAsync(string employeeId, string employeeName)
        {
            var employee = await _employeeBaseRepository.GetAsync(e => e.Fullname == employeeName && e.EmpId == employeeId);
            return employee;
        }

        public async Task AddAsync(Employee employee)
        {
            await _employeeBaseRepository.AddAsync(employee);
        }

        public async Task<int> SaveAsync()
        {
            return await _employeeBaseRepository.SaveAsync();
        }
    }
}
