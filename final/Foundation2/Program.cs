using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public string GetAddressAsString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.GetTotalCost();
        }
        if (Customer.IsInUSA())
            totalPrice += 5;
        else
            totalPrice += 35;
        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"Customer: {Customer.Name}\n";
        label += $"Address: {Customer.Address.GetAddressAsString()}\n";
        return label;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var product1 = new Product
        {
            Name = "Laptop",
            ProductId = 1,
            Price = 799.99,
            Quantity = 2
        };

        var product2 = new Product
        {
            Name = "Mouse",
            ProductId = 2,
            Price = 7.99,
            Quantity = 1
        };

        var customer = new Customer
        {
            Name = "Joseph Ezra Vianzon",
            Address = new Address
            {
                Street = "123 Diamond St",
                City = "San Diego",
                State = "CA",
                Country = "USA"
            }
        };

        var order = new Order
        {
            Products = new List<Product> { product1, product2 },
            Customer = customer
        };

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}