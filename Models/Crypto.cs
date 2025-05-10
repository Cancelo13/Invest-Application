using System;
using System.Text.Json.Serialization;

namespace Invest_Application
{
    public class Crypto : Asset
    {
        [JsonConstructor]
        public Crypto(
            string name,
            int quantity,
            decimal purchasePrice,
            DateTime purchaseDate)
            : base(name, quantity, purchasePrice, purchaseDate)
        {
        }

        public override decimal CurrentPrice()
            => Quantity * DatabaseOrganizer.GetCryptoMarketPrice();
    }
}
