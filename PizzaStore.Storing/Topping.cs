using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Topping
    {
        public int ToppingId { get; set; }
        public int PizzaId { get; set; }
        public string ToppingName { get; set; }

        public virtual Pizza Pizza { get; set; }
    }
}
