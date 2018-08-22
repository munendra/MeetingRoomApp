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
        private Mock<IBookingValidationLogic> _bookingValidation;
        private Mock<IBookingRepository> _bookingRepository;
        private Mock<IRoomFacilityRepository> _roomFacilityRepository;

        [TestInitialize]
        public void Init()
        {
            MapperInit.InitAutoMapper();
            _roomRepository = new Mock<IRoomRepository>();
            _bookingValidation = new Mock<IBookingValidationLogic>();
            _bookingRepository = new Mock<IBookingRepository>();
            _roomFacilityRepository = new Mock<IRoomFacilityRepository>();
            roomLogic = new RoomLogic(_roomRepository.Object, _bookingValidation.Object, _bookingRepository.Object, _roomFacilityRepository.Object);
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


        [TestMethod]
        public async Task RoomLogic_GetAllAsync_ShouldReturnRoomsByFacilityFilterd()
        {
            _roomFacilityRepository.Setup(s => s.GetByRoomIdsAsync(It.IsAny<IEnumerable<Guid>>())).ReturnsAsync(GetRoomFacility);
            _roomRepository.Setup(s => s.GetAllAsync()).ReturnsAsync(GetRooms);
            var filters = new List<Dictionary<string, string>>();
            filters.Add(new Dictionary<string, string>() { { "HasWifi", "1" }, { "HasLargeScreen", "1" } });
            var rooms = await roomLogic.GetAllAsync(25, filters);
            Assert.AreEqual(2, rooms.Count());
        }



        private IEnumerable<Room> GetRooms()
        {
            var rooms = new List<Room>();
            rooms.Add(new Room
            {
                Id = Guid.Parse("4F8E0651-C203-4230-A6CA-699D75CE3363"),
                SeatingCapacity=50,
            });
            rooms.Add(new Room
            {
                Id = Guid.Parse("69A7EBE6-5BA4-4404-91CD-AA7E1466F6EC"),
                SeatingCapacity=50,
            });
            rooms.Add(new Room
            {
                Id = Guid.Parse("ED311234-DC40-454A-BA14-231C84E89304"),
                SeatingCapacity=50
            });

            return rooms;
        }

        private IEnumerable<RoomFacility> GetRoomFacility()
        {
            var roomsFacility = new List<RoomFacility>();
            roomsFacility.Add(new RoomFacility
            {
                RoomId = Guid.Parse("4F8E0651-C203-4230-A6CA-699D75CE3363"),
                Name="HasWifi",
                Value="1"
            });
            roomsFacility.Add(new RoomFacility
            {
                RoomId = Guid.Parse("4F8E0651-C203-4230-A6CA-699D75CE3363"),
                Name = "HasLargeScreen",
                Value = "1"
            });
            roomsFacility.Add(new RoomFacility
            {
                RoomId = Guid.Parse("69A7EBE6-5BA4-4404-91CD-AA7E1466F6EC"),
                Name = "HasWifi",
                Value = "1"
            });
            roomsFacility.Add(new RoomFacility
            {
                RoomId = Guid.Parse("69A7EBE6-5BA4-4404-91CD-AA7E1466F6EC"),
                Name = "HasLargeScreen",
                Value = "1"
            });
            roomsFacility.Add(new RoomFacility
            {
                RoomId = Guid.Parse("ED311234-DC40-454A-BA14-231C84E89304"),
                Name = "HasWifi",
                Value = "0"
            });
            roomsFacility.Add(new RoomFacility
            {
                RoomId = Guid.Parse("ED311234-DC40-454A-BA14-231C84E89304")
            });
            return roomsFacility;
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
