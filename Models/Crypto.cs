namespace Invest_Application
{
    public class Crypto : Asset
    {
        public Crypto(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
            : base(name, quantity, purchasePrice, purchaseDate) { }

        public override decimal CurrentPrice()
        {
            return Quantity * DatabaseOrganizer.GetCryptoMarketPrice();
        }
    }
}
