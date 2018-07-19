using Microgen.Business.Accounting.Exceptions;
using Microgen.Business.Accounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Repositories
{
    public class CurenciesRepo : ICurrenciesRepo
    {
        // TODO: This is dummy data source that would be replaced by call to service or query to database
        // The assumption has been made that the dolar is base currency of the system
        private List<Currency> _rateTable = new List<Currency>
                                                {
                                                  new Currency{ Code = "usd", Rate = 1 },
                                                  new Currency{ Code = "gbp", Rate = 0.77m}
                                                };

        /// <summary>
        /// Return The currency conversion rate based on the base currency
        /// </summary>
        public async Task<decimal> GetBaseRate(string code)
        {
            return await Task.Run(() =>
            {
                var rate = _rateTable.SingleOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

                return rate?.Rate ?? throw new CurrencyNotFountException("The currency \"" + code + "\" Currency has not been found"); ;
            });
        }
    }
}