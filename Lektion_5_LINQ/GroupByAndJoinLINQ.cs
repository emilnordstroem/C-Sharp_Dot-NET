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

		// Task 3
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

		// Task 4
		List<Employee> employees = new List<Employee>
		{
			new Employee { Id = 1, Name = "Alice", DepartmentId = 101 },
			new Employee { Id = 2, Name = "Bob", DepartmentId = 102 },
			new Employee { Id = 3, Name = "Charlie", DepartmentId = 101 }
		};

		List<Department> departments = new List<Department>
		{
			new Department { Id = 101, Name = "HR" },
			new Department { Id = 102, Name = "IT" }
		};
		var employeeDepartment = employees.Join(departments,
			employee => employee.DepartmentId,
			department => department.Id,
			(employee, departent) => new 
			{ 
				EmployeeName = employee.Name,
				DepartmentName = departent.Name
			}
		);
		Console.WriteLine("================== Task 4 ==================");
		employeeDepartment.ToList().ForEach(employee => Console.WriteLine(employee.ToString()));

		// Task 5
		orders = new List<Order>
		{
			new Order { Id = 1, ProductId = 10, Quantity = 2 },
			new Order { Id = 2, ProductId = 11, Quantity = 1 }
		};
		products = new List<Product>
		{
			new Product { Id = 10, Name = "Laptop" },
			new Product { Id = 11, Name = "Mouse" }
		};
		var orderProduct = orders.Join(products, 
			order => order.ProductId,
			product => product.Id,
			(order, product) => new
			{
				Id = order.Id,
				Product = product.Name,
				Quantity = order.Quantity
			}
		);
		Console.WriteLine("================== Task 5 ==================");
		orderProduct.ToList().ForEach(order => Console.WriteLine(order.ToString()));

		// Task 6
		employees = new List<Employee>
		{
			new Employee { Id = 1, Name = "Alice", DepartmentName = "HR" },
			new Employee { Id = 2, Name = "Bob", DepartmentName = "IT" },
			new Employee { Id = 3, Name = "Charlie", DepartmentName = "HR" }
		};
		IEnumerable<IGrouping<string, Employee>> employeesByDepartment = employees.GroupBy(employee => employee.DepartmentName);
		Console.WriteLine("================== Task 6 ==================");
        foreach (var department in employeesByDepartment)
        {
			Console.WriteLine($"{department.Key} Department");
			foreach (var employee in department)
			{
				Console.WriteLine($"{employee.Name}");
			}
		}
	}

}
// Task 1
public class Product
{
	public int Id { get; set; }
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
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Amount { get; set; }
}
// Task 4
public class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int DepartmentId { get; set; }
	public string DepartmentName { get; set; }
}
public class Department
{
	public int Id { get; set; }
	public string Name { get; set; }
}