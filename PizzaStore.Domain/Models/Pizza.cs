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
          case "Small":
            return Convert.ToDecimal(5.00 + toppings.Count * .50);
          case "Medium":
            return Convert.ToDecimal(7.00 + toppings.Count * .50);
          case "Large":
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

    public string SelectSize() 
		{
			System.Console.WriteLine("Please select a size: 1 for Small, 2 for Medium, or 3 for Large");
			int select;
			int.TryParse(Console.ReadLine(), out select);
      do{
        switch(select)
        {
          case 1:
            return "Small";
          case 2:
            return "Medium";
          case 3:
            return "Large";
        } 
      }while(true);
		}

    public List<string> ChooseTopping() 
		{
			int select;
			Boolean cont = true;
			List<string> top = new List<string>(); 

			do{
				System.Console.WriteLine("Select from the list of topping:");
				System.Console.WriteLine("1. Cheese");
				System.Console.WriteLine("2. Pepperoni");
				System.Console.WriteLine("3. Sausage");
				System.Console.WriteLine("4. Mushroom");
				System.Console.WriteLine("5. Jalapeno");
				System.Console.WriteLine("6. Pineapple");
				if (top.Count >= 2)
				{
					System.Console.WriteLine("7. Done adding Topping"); //Require at least 2 topping for a custom pizza.
				}

				int.TryParse(Console.ReadLine(), out select);

				switch(select)
				{
					case 1:
						top.Add("Cheese");
						break;
					case 2:
						top.Add("Pepperoni");
						break;
					case 3:
						top.Add("Sausage");
						break;
					case 4:
						top.Add("Mushroom");
						break;
					case 5:
						top.Add("Jalapeno");
						break;
					case 6:
						top.Add("Pineapple");
						break;
					case 7:
						if (top.Count >= 2)
						{	
							cont = false;
						}
						break;
				}

				if (top.Count == 5) //At most 5 topping requirement
				{
					System.Console.WriteLine("You can not add any more toppings.");
					cont = false;
				}
			} while(cont == true);

			return top;
		}
  
  }
}