using MeetingApp.Domain.Entities;
using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Logic.Implementation;
using MeetingApp.Repository.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeetingApp.Logic.Test
{
    [TestClass]
    public class RoomLogicTest
    {
        private RoomLogic roomLogic;
        private Mock<IRoomRepository> _roomRepository;
        private Mock<IBookingValidation> _bookingValidation;
        private Mock<IBookingRepository> _bookingRepository;

        [TestInitialize]
        public void Init()
        {
            MapperInit.InitAutoMapper();
            _roomRepository = new Mock<IRoomRepository>();
            _bookingValidation = new Mock<IBookingValidation>();
            _bookingRepository = new Mock<IBookingRepository>();
            roomLogic = new RoomLogic(_roomRepository.Object, _bookingValidation.Object, _bookingRepository.Object);
        }

        [TestMethod]
        public async Task RoomLogic_GetAvailableRoom_ShouldCallGetAllAsyncFromRoomRepo()
        {
            await roomLogic.GetAvailableRoom(new DateTime(2018, 08, 22, 15, 00, 00));
            _roomRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [TestMethod]
        public async Task RoomLogic_GetAvailableRoom_ShouldCallGetAllAsyncFromBookingRepo()
        {
            await roomLogic.GetAvailableRoom(new DateTime(2018, 08, 22, 15, 00, 00));
            _bookingRepository.Verify(r => r.GetAllAsync(It.IsAny<DateTime>()), Times.Once);
        }

        [TestMethod]
        public async Task RoomLogic_GetAvailableRoom_ShouldReturnAvailableRoom()
        {
            _roomRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(GetRooms);
            _bookingRepository.Setup(s => s.GetAllAsync(It.IsAny<DateTime>())).ReturnsAsync(GetBookings);
            var rooms = await roomLogic.GetAvailableRoom(new DateTime(2018, 08, 22, 20, 00, 00));
            Assert.IsTrue(rooms.Count() == 2);
        }


        private IEnumerable<Room> GetRooms()
        {
            var rooms = new List<Room>();
            rooms.Add(new Room
            {
                Id = Guid.Parse("4F8E0651-C203-4230-A6CA-699D75CE3363")
            });
            rooms.Add(new Room
            {
                Id = Guid.Parse("69A7EBE6-5BA4-4404-91CD-AA7E1466F6EC")
            });
            rooms.Add(new Room
            {
                Id = Guid.Parse("ED311234-DC40-454A-BA14-231C84E89304")
            });

            return rooms;
        }

        private IEnumerable<Booking> GetBookings()
        {
            var bookings = new List<Booking>();
            bookings.Add(new Booking
            {
                RoomId = Guid.Parse("4F8E0651-C203-4230-A6CA-699D75CE3363"),
                EndTime = new DateTime(2018, 08, 22, 21, 00, 00)
            });
            bookings.Add(new Booking
            {
                Id = Guid.Parse("69A7EBE6-5BA4-4404-91CD-AA7E1466F6EC"),
                EndTime = new DateTime(2018, 08, 22, 15, 00, 00)
            });

            return bookings;
        }
    }
}
