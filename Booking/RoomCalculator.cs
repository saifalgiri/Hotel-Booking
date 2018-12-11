using System;
using System.Collections.Generic;
using System.Text;
using Booking;

namespace Booking
{
    public class RoomCalculator : CalculatorBase<IGuest>
    {
        protected override IEnumerable<CalculatorBase<IGuest>.Room> Rooms
        {
            get
            {
                return new Room[] {

                    //1 room
                    new Room {Test =  new Func<IGuest, bool>(x => x.Adult <= 3 && x.Child <= 3 && x.Infant <= 3), NumberOfRoom = 1},

                    //2 rooms
                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Child > 3 && x.Child <= 6 && x.Infant > 3 && x.Infant <= 6 && x.Adult >= 2 && x.Adult <= 6), NumberOfRoom = 2},
                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Adult >= 2 && x.Adult <= 6 && x.Infant > 3 && x.Infant <= 6 && x.Child > 3   && x.Child <= 6), NumberOfRoom = 2},
                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Adult > 3 && x.Adult <= 6  && x.Infant <= 6  && x.Child <= 6), NumberOfRoom = 2},
                      new Room {Test =  new Func<IGuest, bool>(x =>  x.Child > 3 && x.Infant <= 6 && x.Adult <= 6), NumberOfRoom = 2},
                    // 3 rooms
                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Adult == 7 && x.Infant <= 9 && x.Child  == 0), NumberOfRoom = 3},
                    new Room {Test =  new Func<IGuest, bool>(x => x.Infant > 6 && x.Infant <= 9 && x.Adult >= 3 && x.Adult <= 7), NumberOfRoom = 3},
                };
            }
        }
    }
}
