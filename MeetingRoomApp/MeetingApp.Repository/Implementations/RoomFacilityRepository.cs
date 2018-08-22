using MeetingApp.Domain.Entities;
using MeetingApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace MeetingApp.Repository.Implementations
{
    public class RoomFacilityRepository : IRoomFacilityRepository
    {
        private readonly IBaseRepository<RoomFacility> _baseRepository;
        public RoomFacilityRepository(IBaseRepository<RoomFacility> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<RoomFacility>> GetByRoomIdsAsync(IEnumerable<Guid> roomIds)
        {
            var rooms = await _baseRepository.GetAllAsync(roomFacility => roomIds.Contains(roomFacility.RoomId));
            return rooms;
        }
    }
}
