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
        [Given(@"I have rates repo")]
        public void GivenIHaveRatesRepo()
        {
            ScenarioContext.Current.Set(new FakeCurrenciesRepo());
        }

        [Given(@"I have transactions processor")]
        public void GivenIHaveTransactionsProcessor()
        {
           var repo = ScenarioContext.Current.Get<ICurrenciesRepo>();
            ScenarioContext.Current.Set(new TranasctionsProcessor(repo));
        }

        [When(@"I request rate for ""(.*)""")]
        public async Task WhenIRequestRateFor(string currency)
        {
            var processor = ScenarioContext.Current.Get<TranasctionsProcessor>();

            ScenarioContext.Current.Set(await processor.ConvertToBaseRate(currency), "RateResult");
        }

        [Then(@"the returned rate should be (.*)")]
        public void ThenTheReturnedRateShouldBe(Decimal rate)
        {
           var result = ScenarioContext.Current.Get<decimal>("RateResult");
           result.ShouldBe((decimal)rate);
        }

    }
}
