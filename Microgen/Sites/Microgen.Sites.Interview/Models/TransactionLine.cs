using System;

namespace Microgen.Sites.Interview.Models
{
    public class TransactionLine
    {
        /// <summary>
        /// Transaction financial value (ammount)
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Date Time
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Source Account Number
        /// </summary>
        public string SourceAccNo { get; set; }

        /// <summary>
        /// Dectination Account Number
        /// </summary>
        public string DestinationAccNo { get; set; }
    }
}