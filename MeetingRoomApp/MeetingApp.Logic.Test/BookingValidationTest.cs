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
    public class BookingValidationTest
    {

        private BookingValidation _bookingValidation;
        private Mock<IEmployeeLogic> _EmployeeLogic;
        private Mock<IBookingRepository> _bookingRepo;

        [TestInitialize]
        public void Init()
        {
            _EmployeeLogic = new Mock<IEmployeeLogic>();
            _bookingRepo = new Mock<IBookingRepository>();
            _bookingValidation = new BookingValidation();


        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MeetingRoomBookingLogic_Booking_ShouldThrowExceptionBookingTimeSame()
        {
            var bookings = new List<BookingDto>();
            bookings.Add(new BookingDto
            {
                StartDateTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 16, 00, 00),
                EmployeeId = "Temp-Id"
            });
            bookings.Add(new BookingDto
            {
               
                StartDateTime = new DateTime(2018, 08, 23, 10, 00, 00),
                EndDateTime = new DateTime(2018, 08, 23, 11, 00, 00),
                EmployeeId = "Temp-Id"
            });
           
             _bookingValidation.CheckRoomAvailable(bookings, new DateTime(2018, 08, 22, 14, 00, 00), new DateTime(2018, 08, 22, 16, 00, 00));

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MeetingRoomBookingLogic_Booking_ShouldThrowExceptionBookingStartDateTimeIsInBetweenOfBookedSlot()
        {
            var bookings = new List<BookingDto>();
            bookings.Add(new BookingDto
            {

                StartDateTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 16, 00, 00),
                EmployeeId = "Temp-Id"
            });
            bookings.Add(new BookingDto
            {

                StartDateTime = new DateTime(2018, 08, 23, 10, 00, 00),
                EndDateTime = new DateTime(2018, 08, 23, 11, 00, 00),
                EmployeeId = "Temp-Id"
            });

            _bookingValidation.CheckRoomAvailable(bookings, new DateTime(2018, 08, 22, 15, 00, 00), new DateTime(2018, 08, 22, 16, 00, 00));

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void MeetingRoomBookingLogic_Booking_ShouldThrowExceptionBookingDateTimeIsInBetweenOfBookedSlot()
        {
            var bookings = new List<BookingDto>();
            bookings.Add(new BookingDto
            {

                StartDateTime = new DateTime(2018, 08, 22, 14, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 18, 00, 00),
                EmployeeId = "Temp-Id"
            });
            bookings.Add(new BookingDto
            {

                StartDateTime = new DateTime(2018, 08, 23, 10, 00, 00),
                EndDateTime = new DateTime(2018, 08, 23, 11, 00, 00),
                EmployeeId = "Temp-Id"
            });

            _bookingValidation.CheckRoomAvailable(bookings, new DateTime(2018, 08, 22, 15, 00, 00), new DateTime(2018, 08, 22, 17, 00, 00));

        }
    }
}
