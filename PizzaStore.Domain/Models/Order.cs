using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
	public class Order
	{
		public List<Pizza> Pizzas {get;}
		public void CreatePizza(string name, string size, string crust, List<string> toppings, double price)
		{
			Pizzas.Add(new Pizza(name, size, crust, toppings, price));
		}

		public Order()
		{
			Pizzas = new List<Pizza>();
		}
	}
}