using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
	public class Starter
	{
		public Order CreateOrder(User user, Store store)
		{
			try 
			{
				var order = new Order();

				user.Orders.Add(order);
				store.Orders.Add(order);

				return order;
			}
			catch
			{
				throw new System.Exception("we messed up");
			}
			finally
			{
				//
			}
		}

		internal static void PrintMenu()
		{
		System.Console.WriteLine("Select 1 to add Cheese Pizza");
		System.Console.WriteLine("Select 2 to add Pepperoni Pizza");
		System.Console.WriteLine("Select 3 to add Sausage Pizza");
		System.Console.WriteLine("Select 4 to add Custom Pizza");
		System.Console.WriteLine("Select 5 to  Show Cart");
		System.Console.WriteLine("Select 6 to Exit");
		System.Console.WriteLine();
		}
	}
}