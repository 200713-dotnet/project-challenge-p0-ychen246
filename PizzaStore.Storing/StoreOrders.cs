using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class StoreOrders
    {
        public int StoreOrdersId { get; set; }
        public int StoreId { get; set; }
        public int OrderId { get; set; }
        public bool Complete { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Stores Store { get; set; }
    }
}
