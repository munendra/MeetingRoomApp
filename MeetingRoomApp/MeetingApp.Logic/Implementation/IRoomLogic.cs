﻿using MeetingApp.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Logic.Implementation
{
    public interface IRoomLogic
    {
        Task<IEnumerable<RoomDto>> GetAll();
    }
}
