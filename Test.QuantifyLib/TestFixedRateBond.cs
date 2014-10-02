using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spread.Quantify;

namespace Test.QuantifyLib
{
    [TestClass]
    public class TestFixedRateBond
    {

        [TestMethod]
        public void TestFixedRateBond_NPV_LTN01012015()
        {
            double faceValue = 1000;
            double rate = 0.1211;

            DateTime currentDay = new DateTime(2014,9,11);
            DateTime maturity = new DateTime(2015, 1, 1);

            decimal expectedValue = (decimal)964.799099;
            decimal errorRange = (decimal)0.001;

            LTN bond = new LTN(faceValue, rate, maturity);
            bond.CurrentDate = currentDay;

            decimal diference = Math.Abs(bond.NPV() - expectedValue);
            Assert.IsTrue(diference < errorRange);

        }

        [TestMethod]
        public void TestFixedRateBond_NPV_NTNF01012015()
        {
            double faceValue = 1000;
            double rate = 0.04;
            decimal couponRate = (decimal)0.1;

            DateTime currentDay = new DateTime(2014, 9, 12);
            DateTime maturity = new DateTime(2015, 1, 1);

            decimal expectedValue = (decimal)1036.15355;
            decimal errorRange = (decimal)0.001;

            NTNF bond = new NTNF(faceValue, rate, couponRate, maturity, currentDay);
           
            decimal diference = Math.Abs(bond.NPV() - expectedValue);
            Assert.IsTrue(diference < errorRange);

        }

        [TestMethod]
        public void TestFixedRateBond_NPV_NTNF01012017()
        {
            double faceValue = 1000;
            double rate = 0.09;
            decimal couponRate = (decimal)0.1;

            DateTime currentDay = new DateTime(2014, 9, 15);
            DateTime maturity = new DateTime(2017, 1, 1);

            decimal expectedValue = (decimal)1039.318255;
            decimal errorRange = (decimal)0.001;

            NTNF bond = new NTNF(faceValue, rate, couponRate, maturity, currentDay);
            
            decimal diference = Math.Abs(bond.NPV() - expectedValue);
            Assert.IsTrue(diference < errorRange);

        }

    }
}
