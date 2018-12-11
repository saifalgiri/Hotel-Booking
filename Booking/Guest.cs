using System;
using System.Collections.Generic;
using System.Text;

namespace Booking
{
    public class Guest : IGuest
    {
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
    }
}
