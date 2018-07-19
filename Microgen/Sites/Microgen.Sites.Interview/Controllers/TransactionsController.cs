using Microgen.Sites.Interview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microgen.Sites.Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public async Task<CustomResponse<List<TransactionLine>>> Post([FromBody] IEnumerable<TransactionLine> transactions, [FromQuery(Name = "sortby")] string sortby)
        {
            return await Task.Run(() => {
                var contactList = transactions.ToList();
                return new CustomResponse<List<TransactionLine>>
                {
                    Data = transactions.ToList()
                };
            });
        }
    }
}