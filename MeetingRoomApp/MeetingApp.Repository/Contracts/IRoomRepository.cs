using MeetingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
    }
}
