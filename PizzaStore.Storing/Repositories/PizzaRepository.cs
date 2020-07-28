using domain = PizzaStore.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Storing.Repositories
{
	public class PizzaRepository
	{
		private PizzaStoreDBContext _db = new PizzaStoreDBContext();

		public void Create(domain.Pizza pizza)
		{
			var newPizza = new Pizza();
			
			newPizza.PizzaCrust = pizza.Crust;
			newPizza.Size = pizza.Size;
			newPizza.PizzaName = pizza.Name;
			newPizza.Price = pizza.Price;

			_db.Pizza.Add(newPizza);
			_db.SaveChanges();
			
			var newPizzaTopping = new Topping();
			foreach (string t in pizza.Toppings)
			{
				newPizzaTopping.PizzaId = newPizza.PizzaId;
				newPizzaTopping.ToppingName = t;
				_db.Topping.Add(newPizzaTopping);
				_db.SaveChanges();
			}
		}

		public List<domain.Pizza> ReadAll()
		{
			var domainPizzaList = new List<domain.Pizza>();
			List<string> topList = new List<string>;
			foreach(var pizza in _db.Pizza.ToList())
  		    {
				foreach (var topping in _db.Topping.ToList())
				{	
					if(topping.PizzaId == pizza.PizzaId)
					{
						topList.Add(topping.ToppingName); // Add topping that matches that matches the pizza.
					}
				}

				domainPizzaList.Add(new domain.Pizza(pizza.PizzaName, pizza.Size, pizza.PizzaCrust, topList));  
			}
			return domainPizzaList;
		}

		public void Update()
		{
			
		}

		public void Delete()
		{

		}
	}
}