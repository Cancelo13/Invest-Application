using System;
using System.Text.Json.Serialization;

namespace Invest_Application
{
    public class Stock : Asset
    {
        [JsonConstructor]
        public Stock(
            string name,
            int quantity,
            decimal purchasePrice,
            DateTime purchaseDate)
            : base(name, quantity, purchasePrice, purchaseDate)
        {
        }

        public override decimal CurrentPrice()
            => Quantity * DatabaseOrganizer.GetStockMarketPrice();
    }
}
