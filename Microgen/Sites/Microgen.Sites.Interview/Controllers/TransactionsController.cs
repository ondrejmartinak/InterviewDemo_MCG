using Microgen.Business.Accounting.Exceptions;
using BUSINESS_MODEL = Microgen.Business.Accounting.Models;
using Microgen.Business.Accounting.Processors;
using Microgen.Business.Accounting.Repositories;
using Microgen.Sites.Interview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Microgen.Sites.Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ICurrenciesRepo _repo;

        public TransactionsController(ICurrenciesRepo repo)
        {
            this._repo = repo;
        }

        // POST api/values
        [HttpPost]
        public async Task<CustomResponse<IEnumerable<TransactionLine>>> Post([FromBody] IEnumerable<TransactionLine> transactions, [FromQuery(Name = "sortby")] BUSINESS_MODEL.TransactionSortBy sortby)
        {
            var result = new CustomResponse<IEnumerable<TransactionLine>>();

            try
            {
                var processor = new TranasctionsProcessor(this._repo);
                var businessTranactions = transactions.ToBusinessModel().ToList();

                if (await processor.ValidateTransactions(businessTranactions))
                {
                    var sortedTransactions = await processor.SortTransactions(businessTranactions, sortby);
                    result.Data = sortedTransactions.ToWebsiteModel();
                }
                else
                {
                    result.Errors = new List<string> { "Invalid transaction found. Negative transaction value is not allowed" };
                }
            }
            catch(CurrencyNotFountException ex)
            {
                result.Errors = new List<string> {ex.Message };

            }
            catch
            {
                // TODO LOG the incident to the propriet log storage for future analysis
                result.Errors = new List<string> { "Ups there was an error in our system. Please try again or later." };
            }

            return await Task.Run(() => {
                return result;
            });
        }
    }
}