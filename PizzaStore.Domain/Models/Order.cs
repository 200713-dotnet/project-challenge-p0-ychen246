using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
	public class Order
	{
		public List<Pizza> Pizzas {get;}
		public void CreatePizza(string name, string size, string crust, List<string> toppings)
		{
			Pizzas.Add(new Pizza(name, size, crust, toppings));
		}

		public Order()
		{
			Pizzas = new List<Pizza>();
		}

		public decimal PriceOrder()
		{
			decimal sum;
			sum = Convert.ToDecimal(0.00);
			foreach (Pizza p in Pizzas)
			{
				sum += p.Price;
			}
			return sum;
		}
	}
}