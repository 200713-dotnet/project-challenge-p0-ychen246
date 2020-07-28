using domain = PizzaStore.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Storing.Repositories
{
	public class UserRepository
	{
		private PizzaStoreDBContext _db = new PizzaStoreDBContext();

		public void Create(domain.User User)
		{
			var newUser = new Users();
			newUser.FirstName = User.firstname;
			newUser.LastName = User.lastname;

			_db.Users.Add(newUser);
			_db.SaveChanges();
		}

		public List<domain.User> ReadAll()
		{
			var domainUsersList = new List<domain.User>();
			//Obselete for now. Do not need to list all user.
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