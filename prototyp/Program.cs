using System;
using System.Collections.Generic;


public abstract class ProductPrototype
{
    private decimal price;

    protected ProductPrototype(decimal price)
    {
        this.price = price;
    }


    public ProductPrototype Clone()
    {
        return (ProductPrototype)this.MemberwiseClone();
    }

}


public class Bread : ProductPrototype
{

    public Bread(decimal price) : base(price) { }

}


public class Butter : ProductPrototype
{
    public Butter(decimal price) : base(price) { }
}

public class Supermarket
{

    private Dictionary<string, ProductPrototype> _productList = new Dictionary<string, ProductPrototype>();

    public void AddProduct(string key, ProductPrototype productPrototype)
    {
        _productList.Add(key, productPrototype);
    }

    public ProductPrototype GetClonedProduct(string key)
    {
        return _productList[key].Clone();
    }

}


class MainClass
{
    public static void Main(string[] args)
    {

        var supermarket = new Supermarket();
        //... supermarket
        //... product; 
        ProductPrototype productPrototype = new();
        ProductPrototype product = productPrototype;

        //...
        supermarket.AddProduct("Butter", new Butter(5.30m));
        supermarket.AddProduct("Bread", new Bread(9.50m));


        //...
        product = supermarket.GetClonedProduct("Bread");
        Console.WriteLine(String.Format("Bread - {0} zł", product.Price));
        //...

    }
}