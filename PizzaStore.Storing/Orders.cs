using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Orders
    {
        public Orders()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
            StoreOrders = new HashSet<StoreOrders>();
        }

        public int OrderId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
        public virtual ICollection<StoreOrders> StoreOrders { get; set; }
    }
}
