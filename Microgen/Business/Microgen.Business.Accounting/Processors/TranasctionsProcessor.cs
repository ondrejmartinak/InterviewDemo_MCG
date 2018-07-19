using Microgen.Business.Accounting.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Processors
{
    public static class TranasctionsProcessor
    {
        public static async Task<List<TransactionLine>> SortTransactions(List<TransactionLine> transactions, TransactionSortBy sortBy = TransactionSortBy.Value)
        {
            return await Task.Run(() =>
            {
                return transactions;
            });
        }

        /// <summary>
        /// Ensure no transaction line has negative value
        /// </summary>
        public static async Task<bool> ValidateTransactions(List<TransactionLine> transactions)
        {
            return await Task.Run(() =>
            {
                return !transactions.Any(t => t.Value < 0);
            });
        }
    }
}