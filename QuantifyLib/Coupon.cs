using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class Coupon : CashFlow
    {
        #region "Constant"

        //Truncada na sexta decimal, segundo regra da NTN-B
        private int DECIMAL_ROUNDING = 8;

        #endregion

        #region "Variables"

        private decimal _nominal;
        private decimal _rate;
        private decimal _effectiveRate;
               
        private AccrualDateGroup _accrualGroup;

        private DayCounter _dayCounter;


        #endregion
        
        #region "Properties"

        public decimal Nominal
        {
            get { return _nominal; }
        }

        public decimal Rate
        {
            get { return _rate; }
        }

        public decimal EffectiveRate
        {
            get { return _effectiveRate; }
        }

        public AccrualDateGroup AccrualDates
        {
            get { return _accrualGroup; }
        }


        #endregion

        #region "Public Methods"

        public decimal AccrualPeriodFraction()
        {
            return _dayCounter.PeriodFraction(_accrualGroup.AccrualStartDate, _accrualGroup.AccrualEndDate, _accrualGroup.ReferenceStartDate, _accrualGroup.ReferenceEndDate);
        }

        public long AccrualPeriodDays()
        {
            return _dayCounter.Count(_accrualGroup.AccrualStartDate, _accrualGroup.AccrualEndDate);
        }

        public override decimal Amount()
        {
            return this.Nominal * this.Rate;
        }

        public  decimal AmountAccrued()
        {
            return this.Nominal * this.Rate * this.AccrualPeriodFraction();
        }

        #endregion
      

        public Coupon(decimal nominal, decimal rate, DateTime paymentDate, DayCounter dayCounter, AccrualDateGroup accrualGroup)
            : base(paymentDate, nominal)
        {
            _rate = rate;
            _UpdateEffectiveRate();

            _nominal = nominal;
            _dayCounter = dayCounter;
            _accrualGroup = accrualGroup;
        }

        private void _UpdateEffectiveRate()
        {
            _effectiveRate = Math.Round((decimal)Math.Sqrt(1 + (double)this._rate) - 1, DECIMAL_ROUNDING, MidpointRounding.AwayFromZero);
        }


    }
}
