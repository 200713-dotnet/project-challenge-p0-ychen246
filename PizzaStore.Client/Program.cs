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
				

				switch (select)
				{
					case 1:
						String PizzaSize = SelectSize();
                        order.CreatePizza("Cheese Pizza", PizzaSize , "Regular", new List<string>{"Cheese"});
						System.Console.WriteLine("Added Cheese Pizza");
						break;
					case 2:
						PizzaSize = SelectSize();
                        order.CreatePizza("Pepperoni Pizza", PizzaSize , "Regular", new List<string>{"Pepperoni"});
						System.Console.WriteLine("Added Pepperoni Pizza");
						break;
					case 3:
						PizzaSize = SelectSize();
                        order.CreatePizza("Sausage Pizza", PizzaSize , "Regular", new List<string>{"Sausage"});
						System.Console.WriteLine("Added Sausage Pizza");
						break;
					case 4:
						PizzaSize = SelectSize();
						List<string> toppings = ChooseTopping();
                        order.CreatePizza("Custom Pizza", PizzaSize , "Regular", toppings);
						System.Console.WriteLine("Added CustomPizza");
						break;
					case 5:
						DisplayCart(order);
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

		static string SelectSize()
		{
			System.Console.WriteLine("Please select a size: Small, Medium, or Large");
			return System.Console.ReadLine();
		}

		static List<string> ChooseTopping()
		{
			int select;
			Boolean cont = true;
			List<string> toppings = new List<string>(); 

			do{
				System.Console.WriteLine("Select from the list of topping:");
				System.Console.WriteLine("1. Cheese");
				System.Console.WriteLine("2. Pepperoni");
				System.Console.WriteLine("3. Sausage");
				System.Console.WriteLine("4. Mushroom");
				System.Console.WriteLine("5. Jalapeno");
				System.Console.WriteLine("6. Pineapple");
				if (toppings.Count >= 2)
				{
					System.Console.WriteLine("7. Done adding Topping"); //Require at least 2 topping for a custom pizza.
				}

				int.TryParse(Console.ReadLine(), out select);

				switch(select)
				{
					case 1:
						toppings.Add("Cheese");
						break;
					case 2:
						toppings.Add("Pepperoni");
						break;
					case 3:
						toppings.Add("Sausage");
						break;
					case 4:
						toppings.Add("Mushroom");
						break;
					case 5:
						toppings.Add("Jalapeno");
						break;
					case 6:
						toppings.Add("Pineapple");
						break;
					case 7:
						if (toppings.Count >= 2)
						{	
							cont = false;
						}
						break;
				}

				if (toppings.Count == 5)
				{
					System.Console.WriteLine("You can not add any more toppings.");
					cont = false;
				}
			} while(cont == true);

			return toppings;
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
