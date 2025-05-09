namespace Invest_Application
{
    public class Stock : Asset
    {
        public Stock(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
            : base(name, quantity, purchasePrice, purchaseDate) { }

        public override decimal CurrentPrice()
        {
            return Quantity * DatabaseOrganizer.GetStockMarketPrice();
        }
    }
}
