using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadanie2.Models;

namespace Zadanie2.DTOs
{
    public class Order
    {
        public List<Dish> Dishes { get; set; }
        public double TotalPrice { get; set; }
        public int TableId { get; set; }
        public double Tip { get; set; }
        public double PriceWithTip { get; set; }
        public int CurrentOrder { get; set; }

        public Order(List<Dish> dishes, int id)
        {
            Dishes = dishes;
            TableId = id;
            TotalPrice = CalcPrice(dishes);
            Tip = TotalPrice * 0.05;
            PriceWithTip = TotalPrice * 1.05;
        }

        private double CalcPrice(List<Dish> dishes)
        {
            double sum = 0;
            foreach (var item in dishes)
            {
                sum += item.Price * item.Quantity;
            }

            return sum;

        }

        public Order(int id)
        {
            Dishes = new List<Dish>();
            TableId = id;
        }

        public Order() { }


        public Order(double total, int id)
        {
            TotalPrice = total;
            Tip = TotalPrice * 0.05;
            PriceWithTip = TotalPrice * 1.05;
            TableId = id;
        }

        public void Add(Order order)
        {
            double total = 0;
            if (order == null)
            {
                foreach(var item in Dishes)
                {
                    total += item.TotalPrice;
                }

            }
            else
            {
                for (int i = 0; i < Dishes.Count; i++)
                {
                    Dishes[i].Quantity += order.Dishes[i].Quantity;
                    Dishes[i].TotalPrice = Dishes[i].Quantity * Dishes[i].Price;
                    total += Dishes[i].TotalPrice;
                }
            }
            TotalPrice = total;
            Tip = TotalPrice * 0.05;
            PriceWithTip = TotalPrice + Tip;
        }
    }
}   