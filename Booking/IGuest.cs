using System;
using System.Collections.Generic;
using System.Text;

namespace Booking
{
    public interface IGuest
    {
        int Adult { get; }
        int Child { get; }
        int Infant { get; }

    }
}
