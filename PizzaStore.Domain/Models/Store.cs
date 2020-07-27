using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
	public class Store
	{
		public List<Order> Orders { get; }

		public string Name {get; set;}

		public string Address {get; set;}

		public Store(string n, string a)
    	{
      		Orders = new List<Order>();
			  Name = n;
			  Address = a;
    	}

		public Store()
    	{
      		Orders = new List<Order>();
    	}
	}
}