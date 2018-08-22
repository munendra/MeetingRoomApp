using AutoMapper;
using MeetingApp.Dto;
using MeetingApp.Logic.Implementation;
using MeetingApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Contract
{
    public class RoomLogic : IRoomLogic
    {

        private readonly IRoomRepository _roomRepository;
        public RoomLogic(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDto>> GetAll()
        {
            var rooms = await _roomRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<RoomDto>>(rooms);
        }
    }
}
