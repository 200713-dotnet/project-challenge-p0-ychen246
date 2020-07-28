using domain = PizzaStore.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Storing.Repositories
{
	public class UserRepository
	{
		private PizzaStoreDBContext _db = new PizzaStoreDBContext();

		public void Create(domain.Pizza pizza)
		{
			
		}

		public List<domain.User> ReadAll()
		{
			var domainUsersList = new List<domain.User>();
			
			return domainUsersList;
		}

		public void Update()
		{
			
		}

		public void Delete()
		{

		}
	}
}