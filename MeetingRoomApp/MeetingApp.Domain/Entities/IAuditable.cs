﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingApp.Domain.Entities
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}
