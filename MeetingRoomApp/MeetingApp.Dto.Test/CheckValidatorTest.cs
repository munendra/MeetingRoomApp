using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using MeetingApp.Dto.Validations;
using FluentValidation.TestHelper;
using System;

namespace MeetingApp.Dto.Test
{
    [TestClass]
    public class CheckValidatorTest
    {
        [TestMethod]
        public void CheckValidator_ShouldFailIfStartDateTimeIsEmpty()
        {
            var checkBooking = new CheckValidator();
            checkBooking.ShouldHaveValidationErrorFor(e => e.StartDateTime, default(DateTime));
        }

        [TestMethod]
        public void BookingValidator_ShouldFailIfEndDateTimeIsEmpty()
        {
            var checkBooking = new CheckValidator();
            checkBooking.ShouldHaveValidationErrorFor(e => e.EndDateTime, default(DateTime));
        }

        [TestMethod]
        public void CheckValidator_ShouldFailIfEndDateTimeIsGreaterThenStartDateTime()
        {
            var checkBooking = new CheckValidator();
            var bookingDetails = new CheckBookingDto
            {
                StartDateTime = new DateTime(2018, 08, 22, 12, 00, 00),
                EndDateTime = new DateTime(2018, 08, 22, 11, 00, 00)
            };
            checkBooking.ShouldHaveValidationErrorFor(e => e.EndDateTime, bookingDetails);
        }
    }
}
