using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MeetingApp.Dto.Validations;
using FluentValidation.TestHelper;
using System;

namespace MeetingApp.Dto.Test
{
    [TestClass]
    public class BookingValidatorTest
    {
        [TestMethod]
        public void BookingValidator_ShouldFailIfEmployeeFirstNameIsEmpty()
        {
            var booking = new BookingValidator();
            booking.ShouldHaveValidationErrorFor(e => e.EmployeeName, null as string);
        }

        [TestMethod]
        public void BookingValidator_ShouldFailIfEmployeeIdIsEmpty()
        {
            var booking = new BookingValidator();
            booking.ShouldHaveValidationErrorFor(e => e.EmployeeId, null as string);
        }

        [TestMethod]
        public void BookingValidator_ShouldFailIfStartDateTimeIsEmpty()
        {
            var booking = new BookingValidator();
            booking.ShouldHaveValidationErrorFor(e => e.StartDateTime, default(DateTime));
        }

        [TestMethod]
        public void BookingValidator_ShouldFailIfEndDateTimeIsEmpty()
        {
            var booking = new BookingValidator();
            booking.ShouldHaveValidationErrorFor(e => e.EndDateTime, default(DateTime));
        }

        [TestMethod]
        public void BookingValidator_ShouldFailIfEndDateTimeIsGreaoterThenStartDateTime()
        {
            var bookingVal = new BookingValidator();
            var booking = new BookingDto
            {
                StartDateTime = new DateTime(2018, 08, 22, 12, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 11, 00, 00)
            };
            bookingVal.ShouldHaveValidationErrorFor(e => e.EndDateTime, booking);
        }
    }
}
