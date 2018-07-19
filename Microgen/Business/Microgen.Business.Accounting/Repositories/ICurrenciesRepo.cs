using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Repositories
{
    public interface ICurrenciesRepo
    {
        Task<decimal> GetBaseRate(string code);
    }
}