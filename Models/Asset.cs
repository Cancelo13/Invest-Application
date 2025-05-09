namespace Invest_Application
{
    public abstract class Asset
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        private decimal _PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        protected Asset(string name, int quantity, decimal purchasePrice, DateTime purchaseDate)
        {
            Name = name;
            Quantity = quantity;
            _PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
        }

        public abstract decimal CurrentPrice();

        public virtual decimal PurchasePrice()
        {
            return _PurchasePrice * Quantity;
        }

        public virtual decimal CalculateROI()
        {
            return (CurrentPrice() - PurchasePrice()) / PurchasePrice();
        }
    }
}
