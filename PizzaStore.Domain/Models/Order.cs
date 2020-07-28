using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
	public class Order
	{
		public List<Pizza> Pizzas {get;}

		public DateTime time {get; set;}
		public void CreatePizza(string name, string size, string crust, List<string> toppings)
		{
			if(PriceOrder < 250 || Pizzas.Count < 50) //Less than $250 or 50 pizza requirement
			{
					Pizzas.Add(new Pizza(name, size, crust, toppings));
					if(PriceOrder > 250)
					{
						System.Console.WriteLine("Your pricing exceeds $250 dollar. Please remove one of the pizza."); 
						//Place holder for method to resolve this.
					}
			}
			else
			{
				System.Console.WriteLine("You can not add anymore Pizza because you have 50 pizza in cart or the total price is over $250");
			}
		}

		public Order()
		{
			Pizzas = new List<Pizza>();
		}

		public decimal PriceOrder
		{
			get
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

		public void ListPizzaOrder(Order order)
		{
			int counter = 1;
			foreach (Pizza p in order.Pizzas)
			{
				System.Console.WriteLine("Pizza " + counter + " ; " + p);
				counter += 1;
			}
		}
	}
}