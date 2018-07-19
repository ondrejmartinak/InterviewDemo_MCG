using Microgen.Business.Accounting.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace Microgen.Tests.Business.Accounting
{
    [TestClass]
    public class CurrencyConverterTests
    {
        [DataTestMethod]
        [DataRow("usd", 1.0)]       // This is the default base currency
        [DataRow("gbp", 0.77)]     
        public void ConvertToBaseRate_test(string code, double rate)
        {
            // assert
            CurrencyConverter.ConvertToBaseRate(code).Result.ShouldBe((decimal)rate);
        }

        [DataTestMethod]
        [DataRow("btc")]
        [ExpectedException(typeof(AggregateException), "The currency \"btc\" Currency has not been found")] 
        public void InvalidConvertToBaseRate_test(string code)
        {
            // assert
            var result = CurrencyConverter.ConvertToBaseRate(code).Result; 
        }
    }
}
