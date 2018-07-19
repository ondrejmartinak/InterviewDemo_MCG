using Microgen.Business.Accounting.Exceptions;
using Microgen.Business.Accounting.Models;
using Microgen.Business.Accounting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Processors
{
    public class TranasctionsProcessor
    {
        private ICurrenciesRepo _repo;

        public TranasctionsProcessor(ICurrenciesRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TransactionLine>> SortTransactions(IEnumerable<TransactionLine> transactions, TransactionSortBy sortBy = TransactionSortBy.Value)
        {
            foreach (var line in transactions)
            {
                line.BaseRateValue = line.Value / await ConvertToBaseRate(line.Currency);
            }

            switch (sortBy)
            {
                case TransactionSortBy.Date:
                    //SortByValue(transactions);
                    break;
                default:

                    SortByValue(transactions);
                    break;
            }

            return await Task.Run(() =>
            {
                return transactions.AsEnumerable();
            });
        }



        /// <summary>
        /// Ensure no transaction line has negative value
        /// </summary>
        public async Task<bool> ValidateTransactions(IEnumerable<TransactionLine> transactions)
        {
            return await Task.Run(() =>
            {
                return !transactions.Any(t => t.Value < 0);
            });
        }
        public async Task<decimal> ConvertToBaseRate(string code)
        {
            var currencies = await _repo.GetAll();

            return await Task.Run(() =>
            {
                var rate = currencies.SingleOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

                return rate?.Rate ?? throw new CurrencyNotFountException("The currency \"" + code + "\" is not in our system"); ;
            });
        }

        /// <summary>
        /// Sort transactions by the base rate value
        /// </summary>
        private IEnumerable<TransactionLine> SortByValue(IEnumerable<TransactionLine> transactions)
        {
                return transactions.OrderBy(t => t.BaseRateValue);
        }
    }
}