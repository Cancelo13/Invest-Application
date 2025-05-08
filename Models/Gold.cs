namespace Invest_Application
{
    public class Gold : Asset
    {
        public Gold(string name, int quantity, decimal purchasePrice, DateTime purchaseDate, decimal currentPrice)
            : base(name, quantity, purchasePrice, purchaseDate) { }

        public override decimal CurrentPrice()
        {
            return Quantity * DatabaseOrganizer.GetGoldMarketPrice();
        }
    }
}
