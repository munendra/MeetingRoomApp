using MeetingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
   public interface IRoomFacilityRepository
    {
        Task<IEnumerable<RoomFacility>> GetByRoomIdsAsync(IEnumerable<Guid> roomIds)
    }
}
