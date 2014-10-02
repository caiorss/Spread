using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class DayCounter
    {
        private int _baseDays = 365;

        public int BaseDays
        {
            get { return _baseDays; }
            set { _baseDays = value; }
        }

        public virtual long Count(DateTime from, DateTime until)
        {
            return (from - until).Days;
        }

        public virtual decimal YearFraction(DateTime from, DateTime until)
        {
            _ValidatePeriodFraction(from, until);

            return (from - until).Days / _baseDays;
        }

        public virtual decimal PeriodFraction(DateTime from, DateTime until, DateTime begin, DateTime end)
        {
            _ValidateYearFraction(from, until, begin, end);

            return (from - until).Days / (begin - end).Days;
        }

        private static void _ValidateYearFraction(DateTime from, DateTime until, DateTime begin, DateTime end)
        {
            if ((begin - end).Days == 0)
            {
                throw new ArgumentException("Begin and End Dates cannot be the same day.");
            }

            if (from > until)
            {
                throw new ArgumentException("FROM cannot be later than UNTIL parameter");
            }

            if (begin > end)
            {
                throw new ArgumentException("BEGIN cannot be later than END parameter");
            }
        }

        private static void _ValidatePeriodFraction(DateTime from, DateTime until)
        {
            if (from > until)
            {
                throw new ArgumentException("FROM cannot be later than UNTIL parameter");
            }

        }

    }
}
