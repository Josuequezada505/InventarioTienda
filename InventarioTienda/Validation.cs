public static class Validations
{
    public static bool ValidateProduct(string name, decimal price, int stock)
    {
        if (string.IsNullOrWhiteSpace(name))
            return false;
        if (price <= 0 || stock < 0)
            return false;
        return true;
    }
}


