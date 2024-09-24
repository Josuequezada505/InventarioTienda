﻿public partial class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Category Category { get; set; }

    public bool IsAvailable()
    {
        return Stock > 0;
    }
}
