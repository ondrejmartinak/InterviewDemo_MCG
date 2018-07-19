using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microgen.Business.Accounting.Models;
using Microgen.Business.Accounting.Repositories;

namespace Microgen.Tests.Business.Fakes
{
    public class FakeCurrenciesRepo : ICurrenciesRepo
    {
        public async Task<IQueryable<Currency>> GetAll()
        {
            return await Task.Run(() =>
            {
                return new List<Currency>
                                        {
                                            new Currency{ Code = "usd", Rate = 1 },
                                            new Currency{ Code = "gbp", Rate = 0.77m}
                                        }.AsQueryable();
            });
        }
    }
}