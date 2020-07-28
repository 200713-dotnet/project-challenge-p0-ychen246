using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
	class Program
	{
		static void Main()
		{
                Welcome();
		}

		static void Welcome()
		{
			System.Console.WriteLine("Welcome to Pizza Ordering Service!");
			System.Console.WriteLine("May I have your first name?");
			string fn = Console.ReadLine();
			System.Console.WriteLine("May I have your last name?");
			string ln = Console.ReadLine();
			

			var starter = new Starter();
      		var user = new User(fn, ln);
   			var store = new Store();
			
			try
			{
				Menu(starter.CreateOrder(user, store));
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}

		}

		static void Menu(Order order)
		{
			var exit = false;
			
			do
			{
				Starter.PrintMenu();

				int select;
				int.TryParse(Console.ReadLine(), out select);

				Pizza p = new Pizza();

				switch (select)
				{
					case 1:
						String PizzaSize = p.SelectSize();
                        order.CreatePizza("Cheese Pizza", PizzaSize , "Regular", new List<string>{"Cheese"});
						System.Console.WriteLine("Added Cheese Pizza");
						break;
					case 2:
						PizzaSize = p.SelectSize();
                        order.CreatePizza("Pepperoni Pizza", PizzaSize , "Regular", new List<string>{"Pepperoni"});
						System.Console.WriteLine("Added Pepperoni Pizza");
						break;
					case 3:
						PizzaSize = p.SelectSize();
                        order.CreatePizza("Sausage Pizza", PizzaSize , "Regular", new List<string>{"Sausage"});
						System.Console.WriteLine("Added Sausage Pizza");
						break;
					case 4:
						PizzaSize = p.SelectSize();
						List<string> toppings = p.ChooseTopping();
                        order.CreatePizza("Custom Pizza", PizzaSize , "Regular", toppings);
						System.Console.WriteLine("Added CustomPizza");
						break;
					case 5:
						DisplayCart(order);
						System.Console.WriteLine("Your total price is: $" + order.PriceOrder + "0"); //Display Total Price with cart.
						break;
					case 6:
						var fmw = new FileManager();
						fmw.Write(order);
						System.Console.WriteLine("Thank You!");
						exit = true;
						break;
					case 7:
						var fmr = new FileManager();
						fmr.Read();
						break;
				}

			} while (!exit);

			
		}

		static void DisplayCart(Order order)
		{
			foreach (var pizza in order.Pizzas)
			{
				System.Console.WriteLine(pizza);
			}
		}
	}
}
