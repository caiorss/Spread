using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spread.Quantify;

namespace Test.QuantifyLib
{
    [TestClass]
    public class TestDu252
    {

        [TestMethod]
        public void TestDu252_BusinessDay_NotInitilized()
        {
            long expected = 83;
            long result = BusinessDay.Instance.Count(new DateTime(2014, 1, 1), new DateTime(2014, 5, 5));

            Assert.IsTrue(result == expected);
        }

       
        [TestMethod]
        public void TestDu252_Count()
        {
            Du252 du = new Du252();

            DateTime d1 = new DateTime(2014,1,2);
            DateTime d2 = new DateTime(2014, 1, 9);

            long expected = 6;
            long result = du.Count(d1, d2);

            Assert.IsTrue(result == expected);

        }

        [TestMethod]
        public void TestDu252_PeriodFraction()
        {
            Du252 du = new Du252();

            DateTime d1 = new DateTime(2014, 1, 2);
            DateTime d2 = new DateTime(2014, 1, 9);

            DateTime r1 = new DateTime(2014, 1, 2);
            DateTime r2 = new DateTime(2014, 1, 18);

            decimal expected = (decimal)0.5;
            decimal result = du.PeriodFraction(d1, d2, r1, r2);

            Assert.IsTrue(result == expected);

        }

        [TestMethod]
        public void TestDu252_YearFraction()
        {
            Du252 du = new Du252();

            DateTime d1 = new DateTime(2014, 1, 2);
            DateTime d2 = new DateTime(2014, 1, 9);

            decimal expectedChao = (decimal)0.023;
            decimal expectedTeto = (decimal)0.024;

            decimal result = du.YearFraction(d1, d2);

            Assert.IsTrue(result > expectedChao && result < expectedTeto);

        }
    }
}
