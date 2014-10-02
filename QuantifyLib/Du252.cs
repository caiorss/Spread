using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class Du252 : DayCounter
    {

        private int _baseDays = 252;

        public override long Count(DateTime from, DateTime until)
        {
            return BusinessDay.Instance.Count (from,until);
        }
        
        public override decimal YearFraction(DateTime from, DateTime until)
        {
            long numerator = Count(from, until);

            decimal fraction = (decimal)numerator / (decimal)_baseDays;

            return fraction;
        }

        public override decimal PeriodFraction(DateTime from, DateTime until, DateTime begin, DateTime end)
        {
            long numerator = Count(from, until);
            long denominator = Count(begin, end);

            decimal fraction = (decimal)numerator / (decimal)denominator;

            return fraction;
        }


    }
}
