namespace Invest_Application
{
    public class RealEstate : Asset
    {
        public RealEstate(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
            : base(name, quantity, purchasePrice, purchaseDate) { }

        public override decimal CurrentPrice()
        {
            int years = PurchaseDate.Year - DateTime.Today.Year;
            return Quantity * (DatabaseOrganizer.GetRealEstateMarketExponent() * PurchasePrice * years);
        }
    }
}
