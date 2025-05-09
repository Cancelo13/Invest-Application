namespace Invest_Application
{
    public class RealEstate : Asset
    {
        public RealEstate(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
            : base(name, quantity, purchasePrice, purchaseDate) { }

        public override decimal CurrentPrice()
        {
            int years = DateTime.Today.Year - PurchaseDate.Year;
            decimal total = PurchasePrice * Quantity;
            for (int i = 1; i <= years; i++)
            {
                PurchasePrice *= DatabaseOrganizer.GetRealEstateMarketExponent();
            }
            return total;
        }
    }
}
