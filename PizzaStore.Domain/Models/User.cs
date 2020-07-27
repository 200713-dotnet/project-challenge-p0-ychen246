using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
	public class User
	{
		public List<Order> Orders {get;}
		string firstname {get; set;}
		string lastname {get; set;} 

		public User(string fn, string ln)
		{
			Orders = new List<Order>();
			firstname = fn;
			lastname = ln;
		}

		public User()
		{
			Orders = new List<Order>();
		}
	}
}