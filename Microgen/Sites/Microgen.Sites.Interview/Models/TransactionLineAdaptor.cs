using System.Collections.Generic;
using System.Linq;
using BUSINESS_MODEL = Microgen.Business.Accounting.Models;
using WEBSITE_MODEL = Microgen.Sites.Interview.Models;


namespace Microgen.Sites.Interview.Models
{
    public static class TransactionLineAdaptor
    {
        public static IEnumerable<BUSINESS_MODEL.TransactionLine> ToBusinessModel(this IEnumerable<WEBSITE_MODEL.TransactionLine> transactions)
        {
            return transactions.Select(x => x.ToBusinessModel());
        }

        public static BUSINESS_MODEL.TransactionLine ToBusinessModel(this WEBSITE_MODEL.TransactionLine line)
        {
            return new BUSINESS_MODEL.TransactionLine
            {
                Currency = line.Currency,
                Date = line.Date,
                DestinationAccNo = line.DestinationAccNo,
                SourceAccNo = line.SourceAccNo,
                Value = line.Value
            };
        }

        public static IEnumerable<WEBSITE_MODEL.TransactionLine> ToWebsiteModel(this IEnumerable<BUSINESS_MODEL.TransactionLine> transactions)
        {
            return transactions.Select(x => x.ToWebsiteModel());
        }

        public static WEBSITE_MODEL.TransactionLine ToWebsiteModel(this BUSINESS_MODEL.TransactionLine line)
        {
            return new WEBSITE_MODEL.TransactionLine
            {
                Currency = line.Currency,
                Date = line.Date,
                DestinationAccNo = line.DestinationAccNo,
                SourceAccNo = line.SourceAccNo,
                Value = line.Value
            };
        }
    }
}
