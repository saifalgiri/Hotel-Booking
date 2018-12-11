using Booking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GuestMoreThanSeven()
        {
            //arrange
            var roomValidator = new RoomValidator();
            var guest = new Guest();

            guest = new Guest { Adult =  4, Child = 4, Infant = 0};

            //Act 

            var messages = roomValidator.Validate(guest);

            //assert
            bool result = messages.Any();
            Assert.IsTrue(result);


        }

        [TestMethod]
        public void AdultMoreThanNine()
        {
            //arrange
            var roomValidator = new RoomValidator();
            var guest = new Guest();

            guest = new Guest { Adult = 10, Child = 0, Infant = 0 };

            //Act 

            var messages = roomValidator.Validate(guest);

            //assert
            bool result = messages.Any();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void NoAdultPerBooking()
        {
            //arrange
            var roomValidator = new RoomValidator();
            var guest = new Guest();

            guest = new Guest { Adult = 0, Child = 4, Infant = 2 };

            //Act 

            var messages = roomValidator.Validate(guest);

            //assert
            bool result = messages.Any();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ChildernMoreThanFive()
        {
            //arrange
            var roomValidator = new RoomValidator();
            var guest = new Guest();

            guest = new Guest { Adult = 0, Child = 6, Infant = 0 };

            //Act 

            var messages = roomValidator.Validate(guest);

            //assert
            bool result = messages.Any();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void FourChilderen_OneAdult()
        {
            //arrange
            var roomValidator = new RoomValidator();
            var guest = new Guest();

            guest = new Guest { Adult = 1, Child = 4, Infant = 0 };

            //Act 

            var messages = roomValidator.Validate(guest);

            //assert
            bool result = messages.Any();
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void FourInfants_OneAdult()
        {
            //arrange
            var roomValidator = new RoomValidator();
            var guest = new Guest();

            guest = new Guest { Adult = 1, Child = 3, Infant = 4 };

            //Act 

            var messages = roomValidator.Validate(guest);

            //assert
            bool result = messages.Any();
            Assert.IsTrue(result);

        }



        //estimate number of room needed 

        [TestMethod]
        public void All_less_Than_Three()
        {
            //arrange
            var roomCalculator = new RoomCalculator();
            var guest = new Guest();

            guest = new Guest { Adult = 1, Child = 2, Infant = 3 };

            //Act 

            var rooms = roomCalculator.Calculate(guest);

            //assert
            foreach(var n in rooms)
            {

            Assert.IsTrue(n == 1);
            }

        }

        [TestMethod]
        public void Adult_More_Than_Three()
        {
            //arrange
            var roomCalculator = new RoomCalculator();
            var guest = new Guest();

            guest = new Guest { Adult = 4, Child = 2, Infant = 3 };

            //Act 

            var rooms = roomCalculator.Calculate(guest);

            //assert
            foreach (var n in rooms)
            {

                Assert.IsTrue(n == 2);
            }

        }

        [TestMethod]
        public void Childeren_More_Than_Three()
        {
            //arrange
            var roomCalculator = new RoomCalculator();
            var guest = new Guest();

            guest = new Guest { Adult = 2, Child = 4, Infant = 5 };

            //Act 

            var rooms = roomCalculator.Calculate(guest);

            //assert
            foreach (var n in rooms)
            {

                Assert.IsTrue(n == 2);
            }

        }
    }
}
