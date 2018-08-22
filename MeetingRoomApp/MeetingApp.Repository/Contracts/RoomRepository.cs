using MeetingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingApp.Repository.Contracts
{
    public class RoomRepository: IRoomRepository
    {
        private readonly IBaseRepository<Room> _baseRepository;
        public RoomRepository(IBaseRepository<Room> baseRepository)
        {
            _baseRepository = baseRepository;
        }


        public async Task<IEnumerable<Room>> GetAllAsync()
        {
          return await  _baseRepository.GetAsync();
        }
    }
}
