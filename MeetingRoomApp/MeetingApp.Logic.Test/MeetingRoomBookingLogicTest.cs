using MeetingApp.Domain.Entities;
using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Logic.Implementation;
using MeetingApp.Repository.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Test
{
    [TestClass]
    public class MeetingRoomBookingLogicTest
    {

        private MeetingRoomBookingLogic _meetingRoomBookingLogic;
        private Mock<IEmployeeLogic> _EmployeeLogic;
        private Mock<IBookingRepository> _bookingRepo;
        [TestInitialize]
        public void Init()
        {
            _EmployeeLogic = new Mock<IEmployeeLogic>();
            _bookingRepo = new Mock<IBookingRepository>();
            _meetingRoomBookingLogic = new MeetingRoomBookingLogic(_EmployeeLogic.Object, _bookingRepo.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task MeetingRoomBookingLogic_Booking_ShouldThrowExceptionIfBookingDtoIsNull()
        {
           await _meetingRoomBookingLogic.Booking(null);
        }

        [TestMethod]
        public async Task MeetingRoomBookingLogic_Booking_ShouldCallFetchOrSaveMethodFromEmployeeLogic()
        {
            var booking = new BookingDto
            {
                EmployeeId = "Pro-302",
                EmployeeName = "Test User"
            };

            var bookings = new List<Booking>();
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndTime = new DateTime(2018, 08, 22, 16, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2018, 08, 23, 10, 00, 00),
                EndTime = new DateTime(2018, 08, 23, 11, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            _bookingRepo.Setup(b => b.GetAsync(It.IsAny<Guid>())).ReturnsAsync(bookings);
            await _meetingRoomBookingLogic.Booking(booking);
            _EmployeeLogic.Verify(employeeLogic => employeeLogic.FetchOrSaveAsync(It.IsAny<EmployeeDto>()), Times.Once);
        }

        [TestMethod]
        public async Task MeetingRoomBookingLogic_Booking_ShouldCallGetAsyncFromBookingRepo()
        {
            var booking = new BookingDto
            {
                EmployeeId = "Pro-302",
                EmployeeName = "Test User",
                StartDateTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 16, 00, 00),
            };
            var bookings = new List<Booking>();
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2017, 08, 22, 14, 00, 00),
                EndTime = new DateTime(2017, 08, 22, 16, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2017, 08, 23, 10, 00, 00),
                EndTime = new DateTime(2017, 08, 23, 11, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            _bookingRepo.Setup(b => b.GetAsync(It.IsAny<Guid>())).ReturnsAsync(bookings);
            await _meetingRoomBookingLogic.Booking(booking);
            _bookingRepo.Verify(b => b.GetAsync(It.IsAny<Guid>()), Times.Once);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task MeetingRoomBookingLogic_Booking_ShouldThrowExceptionIsRoomIsNotAvailable()
        {
            var booking = new BookingDto
            {
                EmployeeId = "Pro-302",
                EmployeeName = "Test User",
                StartDateTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 16, 00, 00),
            };
            var bookings = new List<Booking>();
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndTime = new DateTime(2018, 08, 22, 16, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2018, 08, 23, 10, 00, 00),
                EndTime = new DateTime(2018, 08, 23, 11, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            _bookingRepo.Setup(b => b.GetAsync(It.IsAny<Guid>())).ReturnsAsync(bookings);
            await _meetingRoomBookingLogic.Booking(booking);

        }


        [TestMethod]
        public async Task MeetingRoomBookingLogic_Booking_ShouldCallAddAsyncFromBookingRepo()
        {
            var booking = new BookingDto
            {
                EmployeeId = "Pro-302",
                EmployeeName = "Test User",
                StartDateTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 16, 00, 00),
            };
            var bookings = new List<Booking>();
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2018, 08, 22, 09, 00, 00),
                EndTime = new DateTime(2018, 08, 22, 10, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            bookings.Add(new Booking
            {
                Id = Guid.NewGuid(),
                StartTime = new DateTime(2018, 08, 23, 12, 00, 00),
                EndTime = new DateTime(2018, 08, 23, 13, 00, 00),
                EmployeeId = Guid.NewGuid()
            });
            _bookingRepo.Setup(b => b.GetAsync(It.IsAny<Guid>())).ReturnsAsync(bookings);
            await _meetingRoomBookingLogic.Booking(booking);
            _bookingRepo.Verify(b => b.AddAsync(It.IsAny<Booking>()), Times.Once);

        }



    }
}
