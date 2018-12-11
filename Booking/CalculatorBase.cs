using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Booking
{
    public abstract class CalculatorBase<T>
    {
        public class Room
        {
            public Func<T, bool> Test { get; set; }
            public int NumberOfRoom { get; set; }
        }

        protected abstract IEnumerable<Room> Rooms { get; }

        public IEnumerable<int> Calculate(T t)
        {
            return this.Rooms.Where(r => r.Test(t)).Select(r => r.NumberOfRoom);
        }
    }
}
