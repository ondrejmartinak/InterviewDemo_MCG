using Microgen.Business.Accounting.Processors;
using Microgen.Business.Accounting.Repositories;
using Microgen.Tests.Business.Fakes;
using Shouldly;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Microgen.Tests.Business.Steps
{
    [Binding]
    public sealed class TransactionProcessorTestSteps
    {
        private decimal result;
        private FakeCurrenciesRepo repo;
        private TranasctionsProcessor processor;


        [Given(@"I have rates repo")]
        public void GivenIHaveRatesRepo()
        {
            this.repo = new FakeCurrenciesRepo();
        }

        [Given(@"I have transactions processor")]
        public void GivenIHaveTransactionsProcessor()
        {
            this.processor = new TranasctionsProcessor(this.repo);
        }

        [When(@"I request rate for ""(.*)""")]
        public async Task WhenIRequestRateFor(string currency)
        {
            this.result = await this.processor.ConvertToBaseRate(currency);
        }

        [Then(@"the returned rate should be (.*)")]
        public void ThenTheReturnedRateShouldBe(Decimal rate)
        {
           this.result.ShouldBe((decimal)rate);
        }

    }
}
