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

        public async Task<IList<TransactionLine>> SortTransactions(IList<TransactionLine> transactions, TransactionSortBy sortBy = TransactionSortBy.Value)
        {
            foreach (var line in transactions)
            {
                var rate = await ConvertToBaseRate(line.Currency);
                var baseValue = line.Value / rate;
                line.BaseRateValue = baseValue;
            }
            return await Task.Run(() =>
            {
                switch (sortBy)
                {
                    case TransactionSortBy.Date:
                        return SortByDate(transactions);
                    default:
                        return SortByValue(transactions);
                }
            });
        }
        
        /// <summary>
        /// Ensure no transaction line has negative value
        /// </summary>
        public async Task<bool> ValidateTransactions(IList<TransactionLine> transactions)
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
        private IList<TransactionLine> SortByValue(IList<TransactionLine> transactions)
        {
                return transactions.OrderBy(t => t.BaseRateValue).ToList();
        }


        /// <summary>
        /// Sort transactions by the date
        /// </summary>
        private IList<TransactionLine> SortByDate(IList<TransactionLine> transactions)
        {
            return transactions.OrderBy(t => t.Date).ToList();
        }
    }
}