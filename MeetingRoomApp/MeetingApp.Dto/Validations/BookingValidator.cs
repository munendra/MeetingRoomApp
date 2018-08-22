using FluentValidation;
using System;

namespace MeetingApp.Dto.Validations
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {

        public BookingValidator()
        {
            RuleFor(r => r.RoomId).NotEmpty().WithMessage("Room id is required");

            RuleFor(r => r.EmployeeName).NotEmpty().WithMessage("Employee name is required");
            RuleFor(r => r.EmployeeId).NotEmpty().WithMessage("Employee Id is required");

            RuleFor(r => r.StartDateTime).NotEmpty().WithMessage("Meeting start date and time is required");
            RuleFor(r => r.EndDateTime).NotEmpty().WithMessage("Meeting end date and time is required")
                .GreaterThan(r => r.StartDateTime).WithMessage("Invalid end time.");


        }
    }
}
