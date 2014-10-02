using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class FixedRateCoupon : Coupon
    {
        public FixedRateCoupon(decimal nominal, decimal rate, DateTime paymentDate, DayCounter dayCounter, AccrualDateGroup accrualGroup)
        :base(nominal, rate, paymentDate, dayCounter, accrualGroup){

        }
    }
}
