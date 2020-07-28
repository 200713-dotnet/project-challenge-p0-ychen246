using domain = PizzaStore.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Storing.Repositories
{
	public class StoreRepository
	{
		private PizzaStoreDBContext _db = new PizzaStoreDBContext();

		public void Create(domain.Store store)
		{
			var newStore = new Stores();
			newStore.StoreName = store.Name;
			newStore.StoreAddress = store.Address;

			_db.Stores.Add(newStore);
			_db.SaveChanges();
		}

		public List<domain.Store> ReadAll()
		{
			var domainStoreList = new List<domain.Store>();
			foreach (var store in _db.Stores.ToList())
			{
				domainStoreList.Add(new domain.Store(store.StoreName, store.StoreAddress));
			}
			return domainStoreList;
		}

		public void Update()
		{
			
		}

		public void Delete()
		{

		}
	}
}