public static class Extensions
{
    public static decimal CalculateTax(this decimal price, decimal taxRate)
    {
        return price * taxRate;
    }
}
