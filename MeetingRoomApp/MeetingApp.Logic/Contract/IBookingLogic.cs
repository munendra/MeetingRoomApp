using MeetingApp.Dto;
using System;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public  interface IBookingLogic
    {
        Task Booking(BookingDto booking);

        Task<double> Expense(Guid employeeId);
        Task<double> Expense();


    }
}
