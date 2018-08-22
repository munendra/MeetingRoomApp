using AutoMapper;
using MeetingApp.Dto;
using MeetingApp.Logic.Implementation;
using MeetingApp.Repository.Contracts;
using MeetingApp.Resources.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public class RoomLogic : IRoomLogic
    {

        private readonly IRoomRepository _roomRepository;
        private readonly IBookingValidationLogic _bookingValidation;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomFacilityRepository _roomFacilityRepository;

        public RoomLogic(IRoomRepository roomRepository,
            IBookingValidationLogic bookingValidation,
            IBookingRepository bookingRepository,
           IRoomFacilityRepository roomFacilityRepository)
        {
            _roomRepository = roomRepository;
            _bookingValidation = bookingValidation;
            _bookingRepository = bookingRepository;
            _roomFacilityRepository = roomFacilityRepository;
        }

        public async Task<IEnumerable<RoomDto>> GetAll()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<RoomDto>>(rooms);
        }

        public async Task<bool> CheckRoomAvailability(CheckBookingDto checkBooking)
        {
            var roomBookings = await _bookingRepository.GetAsync(checkBooking.RoomId);
            var roomBookingsDto = Mapper.Map<IEnumerable<BookingDto>>(roomBookings);
            var isAvailable = _bookingValidation.IsRoomAvailable(roomBookingsDto, checkBooking.StartDateTime, checkBooking.EndDateTime);
            if (!isAvailable)
            {
                throw new Exception(ErrorMessage.RoomNotAvailable);
            }
            return isAvailable;
        }


        public async Task<IEnumerable<RoomDto>> GetAvailableRoom(DateTime startDate)
        {
            var rooms = Mapper.Map<IEnumerable<RoomDto>>((await _roomRepository.GetAllAsync()));
            var alreadBookedRooms = await _bookingRepository.GetAllAsync(startDate);
            rooms = rooms.Where(r => !alreadBookedRooms.Select(s => s.RoomId).Contains(r.Id));
            return rooms;
        }


        public async Task<IEnumerable<RoomDto>> GetAllAsync(int? seatingCapacity, IEnumerable<Dictionary<string, string>> filters)
        {
            var rooms = await GetAll();
            rooms = rooms.Where(r => r.SeatingCapacity >= seatingCapacity.Value);
            var _roomFacility = await _roomFacilityRepository.GetByRoomIdsAsync(rooms.Select(r => r.Id));
            var roomFacilities = Mapper.Map<IEnumerable<RoomFacilityDto>>(_roomFacility);
            var filterdRoomsFacility = (from filter in filters
                                        select new
                                        {
                                            filterdRoomsFacility = roomFacilities.Where(roomFacility => roomFacility.Name != null
                                            && filter.ContainsKey(roomFacility.Name) && filter[roomFacility.Name] == roomFacility.Value)
                                        }).SelectMany(fr => fr.filterdRoomsFacility.Select(r => r.RoomId)).Distinct();
            rooms = rooms.Where(room => filterdRoomsFacility.Contains(room.Id));

            return rooms;
        }
    }
}
