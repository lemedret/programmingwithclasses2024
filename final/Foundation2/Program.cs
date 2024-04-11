using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Product 1", "P1", 10.0, 2);
        Product product2 = new Product("Product 2", "P2", 5.0, 3);

        // Create some customers
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 High St", "Othertown", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create some orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);

        // Print packing labels, shipping labels, and total prices for the orders
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total price: $" + order1.GetTotalPrice());

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total price: $" + order2.GetTotalPrice());
    }
}

class Product
{
    private string name;
    private string id;
    private double price;
    private int quantity;

    public Product(string name, string id, double price, int quantity)
    {
        this.name = name;
        this.id = id;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetPrice()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetId()
    {
        return id;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public string GetFullAddress()
    {
        return street + "\n" + city + ", " + state + " " + country;
    }
}

class Order
{
    private Customer customer;
    private Product[] products;
    private int numProducts;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new Product[10];
        numProducts = 0;
    }

    public void AddProduct(Product product)
    {
        products[numProducts] = product;
        numProducts++;
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0.0;
        foreach (Product product in products)
        {
            if (product != null)
            {
                totalPrice += product.GetPrice();
            }
        }
        if (customer.IsInUSA())
        {
            totalPrice += 5.0;
        }
        else
        {
            totalPrice += 35.0;
        }
        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            if (product != null)
            {
                packingLabel += product.GetName() + " (" + product.GetId() + ")\n";
            }
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = "";
        shippingLabel += customer.GetName() + "\n";
        shippingLabel += customer.GetAddress().GetFullAddress() + "\n";
        return shippingLabel;
    }
}
