using System;
using System.Collections.Generic;
using System.Text;

public class GroupByAndJoinLINQ
{
    static void Main(string[] args)
    {
		// Task 1
		var products = new List<Product>
		{
			new Product { Name = "Laptop", Category = "Electronics", Price = 999.99m },
			new Product { Name = "Smartphone", Category = "Electronics", Price = 699.99m },
			new Product { Name = "Desk", Category = "Furniture", Price = 299.99m },
			new Product { Name = "Chair", Category = "Furniture", Price = 149.99m },
			new Product { Name = "Headphones", Category = "Electronics", Price = 149.99m },
			new Product { Name = "Monitor", Category = "Electronics", Price = 249.99m },
			new Product { Name = "Sofa", Category = "Furniture", Price = 799.99m }
		};
		var averagePriceByCategory = 
			products
			.GroupBy(product => product.Category)
			.Select(group => new
			{
				Category = group.Key,
				AveragePrice = group.Average(product => product.Price)
			});
		Console.WriteLine("================== Task 1 ==================");
		foreach (var category in averagePriceByCategory)
        {
			Console.WriteLine($"Category: {category.Category}\nAverage Price: {category.AveragePrice}");
        }

		// Task 2
		var customers = new List<Customer>
		{
			new Customer { Id = 1, Name = "Alice" },
			new Customer { Id = 2, Name = "Bob" },
			new Customer { Id = 3, Name = "Charlie" }
		};

		var orders = new List<Order>
		{
			new Order { Id = 101, CustomerId = 1, Amount = 99.99m },
			new Order { Id = 102, CustomerId = 2, Amount = 199.99m },
			new Order { Id = 103, CustomerId = 1, Amount = 49.99m },
			new Order { Id = 104, CustomerId = 3, Amount = 299.99m }
		};
		var customerOrder = customers.Join(
			orders,
			customer => customer.Id,
			order => order.CustomerId,
			(customer, order) => new
			{
				Id = order.Id,
				Customer = customer.Name,
				Amount = order.Amount
			}
		);
		Console.WriteLine("================== Task 2 ==================");
		customerOrder.ToList().ForEach(order => Console.WriteLine($"Order Id: {order.Id}\nCustomer: {order.Customer}\nAmount: {order.Amount}"));

		var mostExpensiveProductByCategory =
			products
			.GroupBy(product => product.Category)
			.Select(group => new 
			{
				Category = group.Key,
				HighestPrice = group.Max(product => product.Price)
			});
		Console.WriteLine("================== Task 3 ==================");
		foreach (var category in mostExpensiveProductByCategory)
		{
			Console.WriteLine($"Category: {category.Category}\nHighest Price: {category.HighestPrice}");
		}
	}

}
// Task 1
public class Product
{
	public string Name { get; set; }
	public string Category { get; set; }
	public decimal Price { get; set; }
}
// Task 2
public class Customer
{
	public int Id { get; set; }
	public string Name { get; set; }
}
public class Order
{
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public decimal Amount { get; set; }
}