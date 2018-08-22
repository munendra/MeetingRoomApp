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
    public class BookingLogic : IBookingLogic
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingValidation _bookingValidation;
        public BookingLogic(IEmployeeLogic employeeLogic, IBookingRepository bookingRepository, IBookingValidation bookingValidation)
        {
            _employeeLogic = employeeLogic;
            _bookingRepository = bookingRepository;
            _bookingValidation = bookingValidation;
        }

        public async Task Booking(BookingDto booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(ErrorMessage.BookingDetailsIsEmpty);
            }
            var employeeId = await GetEmployeeDetails(booking);
            var roombookings = AutoMapper.Mapper.Map<IEnumerable<BookingDto>>(await _bookingRepository.GetAsync(booking.RoomId));
            var isAvailable = _bookingValidation.IsRoomAvailable(roombookings, booking.StartDateTime, booking.EndDateTime);
            if (!isAvailable)
            {
                throw new Exception(ErrorMessage.RoomNotAvailable);
            }
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
