using MeetingApp.Domain.Entities;
using MeetingApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Implementations
{

    public class BookingRepository : IBookingRepository
    {
        private readonly IBaseRepository<Booking> _baseRepository;
        public BookingRepository(IBaseRepository<Booking> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<Booking>> GetAsync(Guid roomId)
        {
            return await _baseRepository.GetAllAsync(booking => booking.RoomId == roomId);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _baseRepository.GetAsync();
        }


        public async Task<IEnumerable<Booking>> GetAllAsync(DateTime fromDatetime)
        {
            return await _baseRepository.GetAllAsync(booking => booking.EndTime > fromDatetime);
        }

        public async Task<Booking> AddAsync(Booking booking)
        {
            return await _baseRepository.AddAsync(booking);
        }

        public async Task<int> SaveAsync()
        {
            return await _baseRepository.SaveAsync();
        }

    }
}
