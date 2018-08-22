using MeetingApp.Domain.Entities;
using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Implementation
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> FetchOrSaveAsync(EmployeeDto employee)
        {
            ValidateEmployee(employee);
            var savedEmployee = await _employeeRepository.GetIdAsync(employee.EmployeeId, employee.EmployeeName);
            if (savedEmployee == null)
            {
                var employeeEntity = new Employee
                {
                    Fullname = employee.EmployeeName,
                    EmpId = employee.EmployeeId
                };
                await _employeeRepository.AddAsync(employeeEntity);
                await _employeeRepository.SaveAsync();
                return employeeEntity.Id;
            }
            else
            {
                return savedEmployee.Id;
            }
        }

        private static void ValidateEmployee(EmployeeDto employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("Invalid employee details");
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
