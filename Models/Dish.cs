
namespace Zadanie2.Models
{
    public class Dish
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Source { get; set; }

        public double TotalPrice { get; set; }

        public Dish(string dishName, double price, string source)
        {
            Name = dishName;
            Price = price;
            Source = source;
            Quantity = 0;
            TotalPrice = 0;
        }

        public void CalcTotalPrice()
        {
            TotalPrice = Quantity * Price;
        }
      
        public Dish() { System.Console.WriteLine("AAAAAAA"); }


    }
}       