using domain = PizzaStore.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace PizzaStore.Storing.Repositories
{
	public class PizzaRepository
	{
		private PizzaStoreDBContext _db = new PizzaStoreDBContext();

		public void Create(domain.Pizza pizza)
		{
			var newPizza = new Pizza();
			
			//newPizza.Crust = pizza.Crust;
			newPizza.Size = pizza.Size;
			//newPizza.Name = pizza.Name;

			_db.Pizza.Add(newPizza);
			_db.SaveChanges();
		}

		//public List<domain.Pizza> ReadAll()
		//{
			
		//}

		public void Update()
		{
			
		}

		public void Delete()
		{

		}
	}
}