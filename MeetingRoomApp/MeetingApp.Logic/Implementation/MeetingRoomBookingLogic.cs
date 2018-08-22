using MeetingApp.Domain.Entities;
using MeetingApp.Dto;
using MeetingApp.Logic.Contract;
using MeetingApp.Repository.Contracts;
using MeetingApp.Resources.ErrorMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MeetingApp.Logic.Implementation
{
    public class MeetingRoomBookingLogic: IMeetingRoomBookingLogic
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IBookingRepository _bookingRepository;
        public MeetingRoomBookingLogic(IEmployeeLogic employeeLogic, IBookingRepository bookingRepository)
        {
            _employeeLogic = employeeLogic;
            _bookingRepository = bookingRepository;
        }
        public async Task Booking(BookingDto booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(ErrorMessage.BookingDetailsIsEmpty);
            }
            var employeeId = await GetEmployeeDetails(booking);

            var roombookings = await _bookingRepository.GetAsync(booking.RoomId);
            CheckRoomAvailable(roombookings, booking.StartDateTime, booking.EndDateTime);
            var bookingEntity = new Booking
            {
                EmployeeId = employeeId,
                RoomId = booking.RoomId,
                StartTime = booking.StartDateTime,
                EndTime = booking.EndDateTime
            };
            await _bookingRepository.AddAsync(bookingEntity);
            await _bookingRepository.SaveAsync();
        }

        private void CheckRoomAvailable(IEnumerable<Booking> bookings, DateTime startDate, DateTime endDateTime)
        {
            var isRoomBooked = bookings.Any(booking => booking.StartTime == startDate && booking.EndTime == endDateTime);
            if (isRoomBooked)
            {
                throw new Exception("Room not available");
            }
        }

        private async Task<Guid> GetEmployeeDetails(BookingDto booking)
        {
            return await _employeeLogic.FetchOrSaveAsync(new EmployeeDto
            {
                EmployeeId = booking.EmployeeId,
                EmployeeName = booking.EmployeeName
            });
        }
    }
}
