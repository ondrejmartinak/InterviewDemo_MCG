using Microgen.Business.Accounting.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Microgen.Business.Accounting.Repositories
{
    public interface ICurrenciesRepo
    {
        Task<IQueryable<Currency>> GetAll();
    }
}