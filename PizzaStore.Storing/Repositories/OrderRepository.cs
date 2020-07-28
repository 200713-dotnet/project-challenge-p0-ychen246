using domain = PizzaStore.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Storing.Repositories
{
	public class OrderRepository
	{
		private PizzaStoreDBContext _db = new PizzaStoreDBContext();

		public void Create(domain.Order order)
		{
			
		}

		public List<domain.Order> ReadAll()
		{
			var domainOrderList = new List<domain.Order>();
			
			return domainOrderList;
		}

		public void Update()
		{
			
		}

		public void Delete()
		{

		}
	}
}