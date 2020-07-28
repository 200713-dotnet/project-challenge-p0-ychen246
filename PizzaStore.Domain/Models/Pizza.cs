using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    
    private List<string> toppings = new List<string>();

    public string Name {get; set;}
    public string Crust { get; set;}
    public string Size { get; set;}
    public List<string> Toppings
    {
      get
      {
        return toppings; 
      }
    }
    public decimal Price 
    {
      get
      {
        switch(Size)
        {
          case "small":
            return Convert.ToDecimal(5.00 + toppings.Count * .50);
          case "medium":
            return Convert.ToDecimal(7.00 + toppings.Count * .50);
          case "large":
            return Convert.ToDecimal(9.00 + toppings.Count * .50);
        }
        return 0;
      }
    }

    public Pizza(string name, string size, string crust, List<string> toppings)
    {
      Name = name;
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
    }

  public Pizza()
  {
  
  }

    void AddToppings(string topping)
    {
      Toppings.Add(topping);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      foreach(var t in Toppings)
      {
        sb.Append(t + ", ");
      }

      return $"{Name} \n{Size} \n{Crust} crust \nTopping: {sb} \n{Price} \n";
    }
  }
}