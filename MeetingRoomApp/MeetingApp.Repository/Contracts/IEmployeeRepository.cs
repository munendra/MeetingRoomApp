using MeetingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetIdAsync(string employeeId, string employeeName);
        Task AddAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<int> SaveAsync();
    }
}
