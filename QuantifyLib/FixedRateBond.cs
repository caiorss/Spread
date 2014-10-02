using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class FixedRateBond : Bond
    {

        #region "Variables"

        protected double _faceValue;        
        protected double _rate;
        protected double _effectiveRate;
        

        private DayCounter _dayCounter;
        private List<Coupon> _coupons = new List<Coupon>();
        
        #endregion
             
        #region "Properties"

        public List<Coupon> Coupons
        {
            get { return _coupons; }
            set { _coupons = value; }
        }


        #endregion

        #region "Constructor"

        public FixedRateBond(double faceValue, double rate, DateTime maturity, DayCounter dayCounter)
        {
            this._faceValue = faceValue;
            this._rate = rate;
            this._maturityDate = maturity;
            this._currentDate = DateTime.Today;
            this._dayCounter = dayCounter;
        }

        public FixedRateBond(double faceValue, double rate, DateTime maturity, DayCounter dayCounter, DateTime currentDate)
        {
            this._faceValue = faceValue;
            this._rate = rate;
            this._maturityDate = maturity;
            this._currentDate = currentDate;
            this._dayCounter = dayCounter;
        }

        #endregion

        #region "Private Methods"

        protected override void PerformCalculate()
        {
            var principal = _CalculatePrincipalPresentValue();

            var coupons = _CalculateCouponsPresentValue();

            _NVP = principal + coupons;
        }

        private decimal _CalculatePrincipalPresentValue()
        {
            DateTime bizMaturityDate = BusinessDay.Instance.CurrentOrNextBusinessDay(_maturityDate);
            DateTime currentBizDay = BusinessDay.Instance.CurrentOrNextBusinessDay(_currentDate.AddDays(1));

            double numberOfPeriods = (double)this._dayCounter.YearFraction(currentBizDay, bizMaturityDate);

            double discount = System.Math.Pow(1 + _rate, numberOfPeriods);
            double presentValue = _faceValue / discount;
            return (decimal)presentValue;
        }

        private decimal _CalculateCouponsPresentValue()
        {
            decimal presentTotalCouponsValue = 0;

            foreach (var coupon in _coupons)
            {
                DateTime bizCouponPaymentDay = BusinessDay.Instance.CurrentOrNextBusinessDay(coupon.PaymentDate);
                DateTime currentBizDay = BusinessDay.Instance.CurrentOrNextBusinessDay(_currentDate.AddDays(1));

                double numberOfPeriods = (double)_dayCounter.YearFraction(currentBizDay, bizCouponPaymentDay);

                double discount = System.Math.Pow(1 + _rate, numberOfPeriods);

                var presentValue = (decimal)(coupon.Nominal * coupon.EffectiveRate / (decimal)discount);

                presentTotalCouponsValue += presentValue;
            }

            return presentTotalCouponsValue;
        }

        #endregion

        #region "Public Methods"

        public override decimal CleanPrice()
        {
            return _NVP;
        }

        public override decimal DirtyPrice()
        {
            return _NVP;
        }

        public override decimal CurrentYield()
        {
            throw new NotImplementedException();
        }

        #endregion

        
    }
}
