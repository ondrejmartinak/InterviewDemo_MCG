using Microgen.Business.Accounting.Models;
using Microgen.Business.Accounting.Processors;
using Microgen.Tests.Business.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;
using System.Collections.Generic;

namespace Microgen.Tests.Business.Processors
{
    [TestClass]
    public class TransactionsProcessorValidateTransactionsTests
    {
        private List<TransactionLine> transactions = FakeTransactionLines.Get();

        [DataTestMethod]
        public void TranasctionsProcessor_ValidateTransactions_test()
        {
            // Test good transactions
            TranasctionsProcessor.ValidateTransactions(transactions).Result.ShouldBe(true);
        }

        [DataTestMethod]
        public void InvalidTranasctionsProcessor_ValidateTransactions_test()
        {
            // Add invalid transaction
            transactions.Add(new TransactionLine
            {
                Currency = "usd",
                Date = DateTime.Now,
                DestinationAccNo = "dest4567",
                SourceAccNo = "source4567",
                Value = -6.15m
            });

            // Test invalid transactions
            TranasctionsProcessor.ValidateTransactions(transactions).Result.ShouldBe(false);
        }
        

    }
}
