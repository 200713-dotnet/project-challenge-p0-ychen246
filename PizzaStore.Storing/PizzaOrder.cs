using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class PizzaOrder
    {
        public int PizzaOrderId { get; set; }
        public int PizzaId { get; set; }
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
