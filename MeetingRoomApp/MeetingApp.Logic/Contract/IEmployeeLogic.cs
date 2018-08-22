using MeetingApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public interface IEmployeeLogic
    {
        Task<Guid> FetchOrSaveAsync(EmployeeDto employee);

        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}
