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
    public class BookingLogicTest
    {

        private BookingLogic _meetingRoomBookingLogic;
        private Mock<IEmployeeLogic> _EmployeeLogic;
        private Mock<IBookingRepository> _bookingRepo;
        private Mock<IBookingValidationLogic> _bookingValidation;
        private Mock<IRoomRepository> _roomRepository;

        [TestInitialize]
        public void Init()
        {
            MapperInit.InitAutoMapper();
            _roomRepository = new Mock<IRoomRepository>();
            _EmployeeLogic = new Mock<IEmployeeLogic>();
            _bookingRepo = new Mock<IBookingRepository>();
            _bookingValidation = new Mock<IBookingValidationLogic>();
            _meetingRoomBookingLogic = new BookingLogic(_EmployeeLogic.Object, _bookingRepo.Object, _bookingValidation.Object, _roomRepository.Object);
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
            _bookingValidation.Setup(s => s.IsRoomAvailable(It.IsAny<IEnumerable<BookingDto>>(),
              It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
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
            _bookingValidation.Setup(s => s.IsRoomAvailable(It.IsAny<IEnumerable<BookingDto>>(),
              It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            await _meetingRoomBookingLogic.Booking(booking);
            _bookingRepo.Verify(b => b.GetAsync(It.IsAny<Guid>()), Times.Once);
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
            _bookingValidation.Setup(s => s.IsRoomAvailable(It.IsAny<IEnumerable<BookingDto>>(),
                It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
            await _meetingRoomBookingLogic.Booking(booking);
            _bookingRepo.Verify(b => b.AddAsync(It.IsAny<Booking>()), Times.Once);

        }

        [TestMethod]
        public async Task BookingLogic_Expense_ShouldReturn6RsAsATotalBookingFees()
        {
            var rooms = new List<Room>();
            rooms.Add(new Room
            {
                Id = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B"),
                Fees = 2
            });
            _roomRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(rooms);
            _bookingRepo.Setup(b => b.GetAllAsync()).ReturnsAsync(GetBookings);
            var totalExpense = await _meetingRoomBookingLogic.Expense();
            Assert.AreEqual(6, totalExpense);
        }


        [TestMethod]
        public async Task BookingLogic_Expense_ShouldReturn5RsAsATotalBookingFees()
        {

            var bookings = new List<Booking>();
            var rooms = new List<Room>();
            rooms.Add(new Room
            {
                Id = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B"),
                Fees = 2
            });
            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 22, 15, 00, 00),
                EndTime = new DateTime(2018, 08, 22, 16, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B"),
            });

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 23, 13, 00, 00),
                EndTime = new DateTime(2018, 08, 23, 13, 30, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B"),
            });

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 24, 15, 00, 00),
                EndTime = new DateTime(2018, 08, 24, 16, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")
            });
            _roomRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(rooms);
            _bookingRepo.Setup(b => b.GetAllAsync()).ReturnsAsync(bookings);
            var totalExpense = await _meetingRoomBookingLogic.Expense();
            Assert.AreEqual(5, totalExpense);
        }


        [TestMethod]
        public async Task BookingLogic_Expense_ShouldReturn4RsAsATotalBookingFeesOfAnEmployee()
        {

            var bookings = new List<Booking>();
            var rooms = new List<Room>();
            rooms.Add(new Room
            {
                Id = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B"),
                Fees = 2
            });
            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CF46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 22, 15, 00, 00),
                EndTime = new DateTime(2018, 08, 22, 16, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")
            });

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 23, 13, 00, 00),
                EndTime = new DateTime(2018, 08, 23, 14, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")

            });

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 24, 15, 00, 00),
                EndTime = new DateTime(2018, 08, 24, 16, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")
            });

            _roomRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(rooms);
            _bookingRepo.Setup(b => b.GetAllAsync()).ReturnsAsync(bookings);
            var totalExpense = await _meetingRoomBookingLogic.Expense(Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"));
            Assert.AreEqual(4, totalExpense);
        }

        private IEnumerable<Booking> GetBookings()
        {
            var bookings = new List<Booking>();

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 22, 15, 00, 00),
                EndTime = new DateTime(2018, 08, 22, 16, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")

            });

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 23, 13, 00, 00),
                EndTime = new DateTime(2018, 08, 23, 14, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")
            });

            bookings.Add(new Booking()
            {
                EmployeeId = Guid.Parse("CE46D642-117F-40FA-AC24-08D60813E185"),
                StartTime = new DateTime(2018, 08, 24, 15, 00, 00),
                EndTime = new DateTime(2018, 08, 24, 16, 00, 00),
                RoomId = Guid.Parse("0F18DBD7-57D4-4E2E-808F-24A4429F4A1B")
            });

            return bookings;
        }

    }
}
