namespace Invest_Application
{
    public abstract class Asset
    {
        public string Name { get; }
        public int Quantity { get; }
        private decimal _PurchasePrice { get; }
        public DateTime PurchaseDate { get; }
        public string id { get; }

        protected Asset(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
        {
            Name = name;
            Quantity = quantity;
            _PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            id = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public abstract decimal CurrentPrice();

        public virtual decimal PurchasePrice()
        {
            return _PurchasePrice;
        }
        public virtual decimal TotalPurchasePrice()
        {
            return _PurchasePrice * Quantity;
        }

        public virtual decimal CalculateROI()
        {
            return (CurrentPrice() - TotalPurchasePrice()) / TotalPurchasePrice();
        }
    }
}
