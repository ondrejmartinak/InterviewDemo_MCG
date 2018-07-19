using Microgen.Business.Accounting.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microgen.Tests.Business.Fakes
{
   public static class FakeTransactionLines
    {
        public static List<TransactionLine> Get()
        {
           return new List<TransactionLine>
                        {
                        new TransactionLine
                            {
                                Currency = "usd",
                                Date = DateTime.Now,
                                DestinationAccNo =  "dest123",
                                SourceAccNo = "source123",
                                Value = 123.06m
                                },
                        new TransactionLine
                            {
                                Currency = "gbp",
                                Date = DateTime.Now.AddHours(2),
                                DestinationAccNo =  "dest123gbp",
                                SourceAccNo = "source123gbp",
                                Value = 123.06m
                                },
                            new TransactionLine
                            {
                                Currency = "usd",
                                Date = DateTime.Now.AddHours(1),
                                DestinationAccNo =  "dest4567",
                                SourceAccNo = "source4567",
                                Value = 220.06m
                                }
                        };
        }
    }
}
