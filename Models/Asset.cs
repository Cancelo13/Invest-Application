namespace Invest_Application
{
    public abstract class Asset
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        protected Asset(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
        {
            Name = name;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
        }

        public abstract decimal CurrentPrice();

        public virtual decimal CalculateROI()
        {
            return CurrentPrice() - PurchasePrice;
        }
    }
}
