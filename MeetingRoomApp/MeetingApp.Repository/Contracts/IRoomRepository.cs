using MeetingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();

        Task<IEnumerable<Room>> GetByIdsAsync(IEnumerable<Guid> roomIds);
    }
}
