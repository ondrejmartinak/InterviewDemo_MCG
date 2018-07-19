using Microgen.Business.Accounting.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Repositories
{
    public class CurrenciesRepo : ICurrenciesRepo
    {
        // TODO: This is dummy data source that would be replaced by call to service or query to database
        // The assumption has been made that the dolar is base currency of the system
        private List<Currency> _rateTable = new List<Currency>
                                                {
                                                  new Currency{ Code = "usd", Rate = 1 },
                                                  new Currency{ Code = "gbp", Rate = 0.77m}
                                                };

        public async Task<IQueryable<Currency>> GetAll()
        {
            return await Task.Run(() =>
            {
                return _rateTable.AsQueryable();
            });
        }
    }
}