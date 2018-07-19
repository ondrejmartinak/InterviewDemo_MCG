using Microgen.Business.Accounting.Processors;
using Microgen.Tests.Business.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace Microgen.Tests.Business.Accounting
{
    [TestClass]
    public class TransactionsProcessorCurrencyConverterTests
    {
        [DataTestMethod]
        [DataRow("usd", 1.0)]       // This is the default base currency
        [DataRow("gbp", 0.77)]     
        public void TransactionsProcessorConvertToBaseRate_test(string code, double rate)
        {
            var processor = new TranasctionsProcessor(new FakeCurrenciesRepo());
            // assert
            processor.ConvertToBaseRate(code).Result.ShouldBe((decimal)rate);
        }

        [DataTestMethod]
        [DataRow("btc")]
        [ExpectedException(typeof(AggregateException), "The currency \"btc\" is not in our system")] 
        public void TransactionsProcessorInvalidConvertToBaseRate_test(string code)
        {
            var processor = new TranasctionsProcessor(new FakeCurrenciesRepo());
            // assert
            var result = processor.ConvertToBaseRate(code).Result; 
        }
    }
}
