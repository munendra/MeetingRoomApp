using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingApp.Domain.Entities
{
    public interface IAuditable
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
