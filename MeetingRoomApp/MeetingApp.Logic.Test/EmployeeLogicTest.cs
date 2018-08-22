using MeetingApp.Domain.Entities;
using MeetingApp.Dto;
using MeetingApp.Logic.Implementation;
using MeetingApp.Repository.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Test
{
    [TestClass]
    public class EmployeeLogicTest
    {

        private EmployeeLogic _employeeLogic;
        private Mock<IEmployeeRepository> _employeeRepository;

        [TestInitialize]
        public void Init()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _employeeLogic = new EmployeeLogic(_employeeRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task EmployeeLogic_FetchOrSave_ShouldThrowExceptionIfBookingDtoIsNull()
        {
            await _employeeLogic.FetchOrSaveAsync(null);
        }

        [TestMethod]
        public async Task EmployeeLogic_FetchOrSaveAsync_ShouldCallGetIdAsyncMethodFromEmployeeRepository()
        {
            var employee = new EmployeeDto
            {
                EmployeeId = "Pro-302",
                EmployeeName = "Test User"
            };
            await _employeeLogic.FetchOrSaveAsync(employee);
            _employeeRepository.Verify(e => e.GetIdAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public async Task EmployeeLogic_FetchOrSaveAsync_ShouldCallAddAsyncMethodFromEmployeeRepository()
        {
            var employee = new EmployeeDto
            {
                EmployeeId = "Pro-302",
                EmployeeName = "Test User"
            };
            _employeeRepository.Setup(e => e.GetIdAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(default(Employee));
            await _employeeLogic.FetchOrSaveAsync(employee);
            _employeeRepository.Verify(e => e.AddAsync(It.IsAny<Employee>()), Times.Once);
        }
    }
}
