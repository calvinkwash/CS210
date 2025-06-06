using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Apple St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B123", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P456", 1.50, 10));

        Address address2 = new Address("456 Pine Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N789", 5.99, 3));
        order2.AddProduct(new Product("Backpack", "BP321", 35.00, 1));

        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
    }
}
