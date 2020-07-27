using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrder = new HashSet<PizzaOrder>();
            Topping = new HashSet<Topping>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<PizzaOrder> PizzaOrder { get; set; }
        public virtual ICollection<Topping> Topping { get; set; }
    }
}
