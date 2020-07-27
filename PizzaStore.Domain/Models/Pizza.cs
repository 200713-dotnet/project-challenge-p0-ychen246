using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    
    private List<string> Toppings = new List<string>();

    public string Name {get; set;}
    public string Crust { get; set;}
    public string Size { get; set;}
    public List<string> Toppings {get; set;}
    public double Price {get; set;}

    public Pizza(string name, string size, string crust, List<string> toppings, double price)
    {
      Name = name;
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
      Price = price;
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

      return $"{Crust} \n{Size} \n{sb} \n";
    }
  }
}