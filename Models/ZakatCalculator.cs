namespace Invest_Application
{
    public class ZakatCalculator
    {
        public decimal CalculateZakat(string username)
        {
            return InvestmentAnalyzer.GetTotalCurrentValue(username) * 0.025m;
        }
    }
}
