using System.Collections.Generic;
using PizzaStore.Domain.Models;
using Xunit;

namespace PizzaStore.Testing.Tests
{
	public class OrderTest
	{
		[Theory]
		[InlineData("N", "S", "C", "T")]
    	[InlineData("N2", "M", "C2", "T2")]	
		public void Test_CreatePizza(string n, string s, string c, string t)
		{
			// arrange 
			var sut = new Order();
			string name = n;
			string size = s;
			string crust = c;
			List<string> toppings = new List<string>{t};

			// act
			sut.CreatePizza(name, size, crust, toppings);

			// check
			Assert.True(sut.Pizzas.Count == 1);
		}
	}
}