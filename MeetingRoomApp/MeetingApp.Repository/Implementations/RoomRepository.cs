using MeetingApp.Domain.Entities;
using MeetingApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace MeetingApp.Repository.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IBaseRepository<Room> _baseRepository;
        public RoomRepository(IBaseRepository<Room> baseRepository)
        {
            _baseRepository = baseRepository;
        }


        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _baseRepository.GetAsync();
        }

        public async Task<IEnumerable<Room>> GetByIdsAsync(IEnumerable<Guid> roomIds)
        {
            var rooms = await _baseRepository.GetAllAsync(r => roomIds.Contains(r.Id));
            return rooms;
        }
    }
}
