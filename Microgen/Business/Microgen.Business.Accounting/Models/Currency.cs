namespace Microgen.Business.Accounting.Models
{
    public class Currency
    {
        /// <summary>
        /// Currency Code ie. usd, gbp, eur
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Currency display name ie. Us Dolar, British Pound, Euro
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Conversion rate
        /// </summary>
        public decimal Rate { get; set; }
    }
}