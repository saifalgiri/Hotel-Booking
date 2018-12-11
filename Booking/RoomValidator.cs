using System;
using System.Collections.Generic;
using System.Text;

namespace Booking
{
    public class RoomValidator: ValidatorBase<IGuest>
    {
        protected override IEnumerable<ValidatorBase<IGuest>.Rule> Rules
        {
            get
            {
                return new Rule[] {

                    //max guest
                    new Rule {Test =  new Func<IGuest, bool>(x => (x.Adult + x.Child) > 7),ErrorMessage = "Guest cannot be more than 7 per booking"},

                    //max childeren
                    new Rule { Test = new Func<IGuest,bool>(x => x.Child > 5), ErrorMessage = "One adult cannot take care of childeren in 2 rooms" },

                    //max infants
                    new Rule { Test = new Func<IGuest,bool>(x => x.Infant >  9 ), ErrorMessage = "Infants cannot be more than 9 per booking" },

                    //at least one adult per booking
                    new Rule { Test = new Func<IGuest,bool>(x => x.Adult <= 0), ErrorMessage = "Booking must have at least one adult" },

                    //at least 2 adults if childeren more than 3
                    new Rule { Test = new Func<IGuest,bool>(x => x.Child >  3 && x.Child <= 5 && x.Adult < 2 ), ErrorMessage = "Must be 2 adults to take care of childeren in 2 rooms" },

                    //at least 2 adults if infants more than 3
                    new Rule { Test = new Func<IGuest,bool>(x => x.Infant >  3 && x.Infant <= 6 && x.Adult < 2 ), ErrorMessage = "Must be 2 adults to take care of infants in 2 rooms" },

                    new Rule { Test = new Func<IGuest,bool>(x => x.Infant >  6 && x.Adult < 3 ), ErrorMessage = "Must be at least 3 adults to take care of infants in 3 rooms" },

                };
            }
        }
    }
}
