using Microgen.Business.Accounting.Models;
using Microgen.Business.Accounting.Processors;
using Microgen.Tests.Business.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

namespace Microgen.Tests.Business.Processors
{
    [TestClass]
    public class TransactionsProcessorSortTransactionsTests
    {
        private List<TransactionLine> transactions = FakeTransactionLines.Get();

        [DataTestMethod]
        public void SortTransactionsByValue_test()
        {
            var processor = new TranasctionsProcessor(new FakeCurrenciesRepo());

            var result = processor.SortTransactions(transactions, TransactionSortBy.Value).Result;

            result.First().Currency.ShouldBe("usd");
            result.First().Value.ShouldBe(123.06m);

            result.Last().Currency.ShouldBe("usd");
            result.Last().Value.ShouldBe(220.06m);
        }

        [DataTestMethod]
        public void SortTransactionsByDate_test()
        {
            var processor = new TranasctionsProcessor(new FakeCurrenciesRepo());

            var result = processor.SortTransactions(transactions, TransactionSortBy.Date).Result;

            result.First().Currency.ShouldBe("usd");
            result.First().Value.ShouldBe(123.06m);

            result.Last().Currency.ShouldBe("gbp");
            result.Last().Value.ShouldBe(123.06m);
        }
    }
}