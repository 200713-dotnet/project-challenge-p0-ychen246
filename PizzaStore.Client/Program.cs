﻿using System;
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
                        order.CreatePizza("L", "Stuffed", new List<string>{"cheese"});
						System.Console.WriteLine("Added Cheese Pizza");
						break;
					case 2:
						order.CreatePizza("L", "Stuffed", new List<string>{"pepperoni"});
						System.Console.WriteLine("Added Pepperoni Pizza");
						break;
					case 3:
						order.CreatePizza("L", "Stuffed", new List<string>{"pineapple"});
						System.Console.WriteLine("Added Pineapple Pizza");
						break;
					case 4:
						order.CreatePizza("L", "Stuffed", new List<string>{"custom"});
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

				//DisplayCart(cart); 

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