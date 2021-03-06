﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Quantify
{
    public class NTNC : FloatingRateBond
    {
        private decimal _couponRate;

        public double IGPM
        {
            get { return _index; }
            set { _index = value; }
        }


        public NTNC(double faceValue, double rate, decimal couponRate,DateTime maturity) :
        base(faceValue, rate, maturity, new Du252 ()){
            _couponRate = couponRate;
            GenerateCoupons();
        }

        public NTNC(double faceValue, double rate, decimal couponRate, DateTime maturity, DateTime currentDate) :
            base(faceValue, rate, maturity, new Du252(), currentDate)
        {
            _couponRate = couponRate;
            GenerateCoupons();
        }

        public void GenerateCoupons()
        {
            DateTime couponDate = _maturityDate;

            do
            {
                Coupon coupon = new Coupon((decimal)this._faceValue, (decimal)this._couponRate, couponDate, new Du252(), new AccrualDateGroup(this.CurrentDate, this.CurrentDate));
                this.Coupons.Add(coupon);

                couponDate = couponDate.AddMonths(-6);

            } while (couponDate > this.CurrentDate);

            

        }
    }
}
