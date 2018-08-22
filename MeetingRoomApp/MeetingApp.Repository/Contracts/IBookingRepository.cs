using MeetingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
  public  interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAsync(Guid roomId);

        Task<Booking> AddAsync(Booking booking);

        Task<int> SaveAsync();
    }
}
