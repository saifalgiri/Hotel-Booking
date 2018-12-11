using Booking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking
{
    public class Program
    {
        public static bool valid = false;

        public static void Main(string[] args)
        {
            bool input1, input2, input3;
            int adult, child, infant;

            var roomValidator = new RoomValidator();
            var guest = new Guest(); 
            do
            {
                do
                {
                    input1 = input2 = input3 = valid = false;
                    //new Guest { Adult = 0, Child = 0, Infant = 0 };
                    Console.WriteLine("Enter number of Adult: ");
                    input1 = int.TryParse(Console.ReadLine(), out adult);
                    if (input1) guest.Adult = adult;

                    Console.WriteLine("Enter number of Child: ");
                    input2 = int.TryParse(Console.ReadLine(), out child);
                    if (input2) guest.Child = child;

                    Console.WriteLine("Enter number of Infants: ");
                    input3 = int.TryParse(Console.ReadLine(), out infant);
                    if (input3) guest.Infant = infant;

                    var messages = roomValidator.Validate(guest);
                    if (messages.Any())
                    {
                        valid = true;
                        foreach (var ErrorMessage in messages) Console.WriteLine("Error: " + ErrorMessage);

                    }
                } while (valid || !input1 || !input2 || !input3);

                //calculate 
                var roomCalculator = new RoomCalculator();
                var num = roomCalculator.Calculate(guest);
                if (!num.Any()) Console.WriteLine("Valid");
                else foreach (var no in num)
                    {
                        Console.WriteLine("Number of room needed is: " + no);
                        break;
                    }

                Console.WriteLine("To redo please enter y/n");

            } while (Console.ReadLine().Equals("y"));

            Console.ReadKey();
        }
    }
}

    //public interface IGuest
    //{
    //    int Adult { get; }
    //    int Child { get; }
    //    int Infant { get; }

    //}
    //public class Guest : IGuest
    //{
    //    public int Adult { get; set; }
    //    public int Child { get; set; }
    //    public int Infant { get; set; }
    //}

    //public abstract class ValidatorBase<T>
    //{
    //    public class Rule
    //    {
    //        public Func<T, bool> Test { get; set; }
    //        public string ErrorMessage { get; set; }
    //    }

    //    protected abstract IEnumerable<Rule> Rules { get; }

    //    public IEnumerable<string> Validate(T t)
    //    {
    //        return this.Rules.Where(r => r.Test(t)).Select(r => r.ErrorMessage);
    //    }
    //}

   

    //public class RoomValidator : ValidatorBase<IGuest>
    //{
    //    protected override IEnumerable<ValidatorBase<IGuest>.Rule> Rules
    //    {
    //        get
    //        {
    //            return new Rule[] {

    //                //max guest
    //                new Rule {Test =  new Func<IGuest, bool>(x => (x.Adult + x.Child) > 7),ErrorMessage = "Guest cannot be more than 7 per booking"},

    //                //max childeren
    //                new Rule { Test = new Func<IGuest,bool>(x => x.Child > 5), ErrorMessage = "One adult cannot take care of childeren in 2 rooms" },

    //                //max infants
    //                new Rule { Test = new Func<IGuest,bool>(x => x.Infant >  9 ), ErrorMessage = "Infants cannot be more than 9 per booking" },

    //                //at least one adult per booking
    //                new Rule { Test = new Func<IGuest,bool>(x => x.Adult <= 0), ErrorMessage = "Booking must have at least one adult" },

    //                //at least 2 adults if childeren more than 3
    //                new Rule { Test = new Func<IGuest,bool>(x => x.Child >  3 && x.Child <= 5 && x.Adult < 2 ), ErrorMessage = "Must be 2 adults to take care of childeren in 2 rooms" },

    //                //at least 2 adults if infants more than 3
    //                new Rule { Test = new Func<IGuest,bool>(x => x.Infant >  3 && x.Infant <= 6 && x.Adult < 2 ), ErrorMessage = "Must be 2 adults to take care of infants in 2 rooms" },

    //                new Rule { Test = new Func<IGuest,bool>(x => x.Infant >  6 && x.Adult < 3 ), ErrorMessage = "Must be at least 3 adults to take care of infants in 3 rooms" },
                    
    //            };
    //        }
    //    }
    //}

//public abstract class CalculatorBase<T>
//{
//    public class Room
//    {
//        public Func<T, bool> Test { get; set; }
//        public int NumberOfRoom { get; set; }
//    }

//    protected abstract IEnumerable<Room> Rooms { get; }

//    public IEnumerable<int> Calculate(T t)
//    {
//        return this.Rooms.Where(r => r.Test(t)).Select(r => r.NumberOfRoom);
//    }
//}


//public class RoomCalculator : CalculatorBase<IGuest>
//{
//    protected override IEnumerable<CalculatorBase<IGuest>.Room> Rooms
//    {
//        get
//        {
//            return new Room[] {

//                    //1 room
//                    new Room {Test =  new Func<IGuest, bool>(x => x.Adult <= 3 && x.Child <= 3 && x.Infant <= 3), NumberOfRoom = 1},

//                    //2 rooms
//                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Child > 3 && x.Child <= 6 && x.Infant > 3 && x.Infant <= 6 && x.Adult >= 2 && x.Adult <= 6), NumberOfRoom = 2},
//                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Adult >= 2 && x.Adult <= 6 && x.Infant > 3 && x.Infant <= 6 && x.Child > 3   && x.Child <= 6), NumberOfRoom = 2},
//                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Adult > 3 && x.Adult <= 6  && x.Infant <= 6  && x.Child <= 6), NumberOfRoom = 2},
//                      new Room {Test =  new Func<IGuest, bool>(x =>  x.Child > 3 && x.Infant <= 6 && x.Adult <= 6), NumberOfRoom = 2},
//                    // 3 rooms
//                    new Room {Test =  new Func<IGuest, bool>(x =>  x.Adult == 7 && x.Infant <= 9 && x.Child  == 0), NumberOfRoom = 3},
//                    new Room {Test =  new Func<IGuest, bool>(x => x.Infant > 6 && x.Infant <= 9 && x.Adult >= 3 && x.Adult <= 7), NumberOfRoom = 3},
//                };
//        }
//    }
//}