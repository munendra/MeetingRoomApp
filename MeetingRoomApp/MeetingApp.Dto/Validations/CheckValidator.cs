using FluentValidation;
using System;

namespace MeetingApp.Dto.Validations
{
    public class CheckValidator : AbstractValidator<CheckBookingDto>
    {

        public CheckValidator()
        {
            RuleFor(r => r.RoomId).NotEmpty().WithMessage("Room id is required");
            RuleFor(r => r.StartDateTime).NotEmpty().WithMessage("Meeting start date and time is required");
            RuleFor(r => r.EndDateTime).NotEmpty().WithMessage("Meeting end date and time is required")
                .GreaterThan(r => r.StartDateTime).WithMessage("Invalid end time.");
        }
    }
}
