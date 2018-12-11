using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Booking
{
    public abstract class ValidatorBase<T>
    {
        public class Rule
        {
            public Func<T, bool> Test { get; set; }
            public string ErrorMessage { get; set; }
        }

        protected abstract IEnumerable<Rule> Rules { get; }

        public IEnumerable<string> Validate(T t)
        {
            return this.Rules.Where(r => r.Test(t)).Select(r => r.ErrorMessage);
        }
    }
}
