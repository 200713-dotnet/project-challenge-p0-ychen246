using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Stores
    {
        public Stores()
        {
            StoreOrders = new HashSet<StoreOrders>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<StoreOrders> StoreOrders { get; set; }
    }
}
