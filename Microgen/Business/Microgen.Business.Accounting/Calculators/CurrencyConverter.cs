using Microgen.Business.Accounting.Repositories;
using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Calculators
{
    public static class CurrencyConverter
    {
        public static async Task<decimal> ConvertToBaseRate(string code)
        {
            return await new CurenciesRepo().GetBaseRate(code);
        }
    }
}