using Microgen.Business.Accounting.Models;
using Microgen.Business.Accounting.Processors;
using Microgen.Tests.Business.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Microgen.Tests.Business.Processors
{
    [TestClass]
    public class TransactionsProcessorSortTransactionsTests
    {
        private List<TransactionLine> transactions = FakeTransactionLines.Get();

        [DataTestMethod]
        public void SortTransactions_test()
        {
            var processor = new TranasctionsProcessor(new FakeCurrenciesRepo());



            var result = processor.SortTransactions(transactions).Result;
        }
    }
}