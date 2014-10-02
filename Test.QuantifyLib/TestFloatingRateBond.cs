using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spread.Quantify;

namespace Test.QuantifyLib
{
    [TestClass]
    public class TestFloatingRateBond
    {

        [TestMethod]
        public void TestFloatingRateBond_NPV_NTNB()
        {
            double faceValue = 1000;
            double rate = 0.1;
            decimal couponRate = (decimal)0.06;


            DateTime currentDay = new DateTime(2014, 9, 23);
            DateTime maturity = new DateTime(2015, 5, 15);

            decimal expectedValue = (decimal)2455.833738;
            decimal errorRange = (decimal)0.001;

            NTNB bond = new NTNB(faceValue, rate,couponRate, maturity);
            bond.IPCA = 1.461073427;

            bond.CurrentDate = currentDay;

            decimal diference = Math.Abs(bond.NPV() - expectedValue);
            Assert.IsTrue(diference < errorRange);

        }

        [TestMethod]
        public void TestFloatingRateBond_NPV_NTNC()
        {
            double faceValue = 1000;
            double rate = 0.1;
            decimal couponRate = (decimal)0.06;


            DateTime currentDay = new DateTime(2014, 9, 23);
            DateTime maturity = new DateTime(2015, 5, 15);

            decimal expectedValue = (decimal)2455.833738;
            decimal errorRange = (decimal)0.001;

            NTNC bond = new NTNC(faceValue, rate, couponRate, maturity);
            bond.IGPM = 1.461073427;

            bond.CurrentDate = currentDay;

            decimal diference = Math.Abs(bond.NPV() - expectedValue);
            Assert.IsTrue(diference < errorRange);

        }

        [TestMethod]
        public void TestFloatingRateBond_NPV_LFT()
        {
            double faceValue = 1000;
            double rate = -0.000006;

            DateTime currentDay = new DateTime(2007, 7, 3);
            DateTime maturity = new DateTime(2010, 6, 7);

            decimal expectedValue = (decimal)3144.606695;
            decimal errorRange = (decimal)0.001;

            LFT bond = new LFT(faceValue, rate, maturity);
            bond.SELIC = 2.14455;

            bond.CurrentDate = currentDay;

            decimal diference = Math.Abs(bond.NPV() - expectedValue);
            Assert.IsTrue(diference < errorRange);

        }

    }
}
